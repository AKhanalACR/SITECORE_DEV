 'use strict';

var gulp = require('gulp');
var gulpIf = require('gulp-if');
var autoprefixer = require('gulp-autoprefixer');
var cleanCss = require('gulp-clean-css');
var sass = require('gulp-sass');
var handlebars = require('gulp-compile-handlebars');
var sourcemaps = require('gulp-sourcemaps');
var helpers = require('handlebars-helpers');
var named = require('vinyl-named');
var webpack = require('webpack');
var webpackStream = require('webpack-stream');
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var foreach = require("gulp-flatmap");
var gulpConfig = require("./gulp-config.js")();
var exec = require('child_process').exec;
var nuget = require('gulp-nuget');
var argv = require('yargs').argv;
var uglify = require("gulp-uglify-es").default;
var minifyCss = require("gulp-clean-css");
var del = require('del');
var concat = require('gulp-concat');
var replace = require('gulp-string-replace');
var path = require('path');

module.exports.config = gulpConfig;

var currentBuildConfig = '';
var CustomPath;
var BundleMinifyAssets = true;
var PRODUCTION = true;
var BUILD_PROD_JS = true;

gulp.task("Deploy-Prod-Auth",
    gulp.series(
        function (cb) {
            currentBuildConfig = 'Prod-Auth';
            gulpConfig.webRoot = path.resolve("../../Output/ProdAT");
            gulpConfig.ACRPassword = argv.Password;
            gulpConfig.ACRUser = argv.User;
            cb();
        },
        deleteDeployDirectory,
        buildAllCSS,
        buildJS,
        UpdateAcrCssBundle,
        UpdateDsiCssBundle,
        UpdateARCJsBundle,
        PublishFoundationProjects,
        PublishFeatureProjects,
        PublishMicrositeProjects,
        PublishProjectProjects,
        MinifyJs,
        CopyCSS,
        MinifyCss,
        DeleteUnicorns,
        CopyUnicorns,
        DeleteUnnessaryFolder
    ));

gulp.task("Deploy-Prod-Preview",
    gulp.series(
        function (cb) {
	     BundleMinifyAssets = true;
            currentBuildConfig = 'Prod-Preview';
            gulpConfig.webRoot = path.resolve("../../Output/ProdPreview");
            gulpConfig.ACRPassword = argv.Password;
            gulpConfig.ACRUser = argv.User;
            cb();
        },
        deleteDeployDirectory,
        buildAllCSS,
        buildJS,
        UpdateAcrCssBundle,
        UpdateDsiCssBundle,
        UpdateARCJsBundle,
        PublishFoundationProjects,
        PublishFeatureProjects,
        PublishMicrositeProjects,
        PublishProjectProjects,
        MinifyJs,
        CopyCSS,
        MinifyCss,
        DeleteUnicorns,
        DeleteConfigFolder,
        DeleteUnnessaryFolder
    ));

gulp.task("Deploy-Prod-CD",
    gulp.series(
        function (cb) {
            currentBuildConfig = 'Prod-CD1';
            gulpConfig.webRoot = path.resolve("../../Output/ProdCD");
            gulpConfig.ACRPassword = argv.Password;
            gulpConfig.ACRUser = argv.User;
            cb();
        },
        deleteDeployDirectory,
        buildAllCSS,
        buildJS,
        UpdateAcrCssBundle,
        UpdateDsiCssBundle,
        UpdateARCJsBundle,
        PublishFoundationProjects,
        PublishFeatureProjects,
        PublishMicrositeProjects,
        PublishProjectProjects,
        MinifyJs,
        CopyCSS,
        MinifyCss,
        DeleteUnicorns,
        DeleteConfigFolder,
        DeleteUnnessaryFolder
    ));

//gulp build and deploy project
function updateNuget() {
    var options = {
        nuget: './nuget.exe', //./nuget.exe
        packagesDirectory: './packages'
    };
    return gulp.src('./ACRHelix.sln').pipe(nuget.restore(options));
}


function roboCopyDeploy(cb) {
    exec('robocopy ' + gulpConfig.webRoot + ' \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + ' /E /FFT /W:6', function (err, stdout, stderr) {
        //return exec('robocopy ' + 'C:\\Workspaces\\ACRHelix-UATAuth\\Deploy' + ' E:\\uatauth /E /FFT /W:3 ', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        //console.log(err);
        cb();
    });
};

function netUseRemoveAcrNetwork(callback) {
    exec('net use /delete \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder, function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);

        callback();
    });
};

function netUseAcrNetwork(callback) {
    exec('net use \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + ' ' + gulpConfig.ACRPassword + ' /user:' + gulpConfig.ACRUser, function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        if (err != null) {
            process.exit(1);
        }
        callback();
    });
};

function DeleteUnicorns(callback) {
    exec('rmdir \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + '\\App_Data\\Unicorn2 /s /q', function (err, stdout, stderr) {
        //return exec('rmdir e:\\uatauth' + '\\App_Data\\Unicorn /s /q', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        callback();
    });
};

function RobocopyUnicorns(cb) {
    exec('robocopy ..\\..\\Unicorn \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + '\\App_Data\\Unicorn2' + ' /E /FFT /W:3 /xd ".svn"', function (err, stdout, stderr) {
        //return exec('robocopy ..\\..\\Unicorn e:\\uatauth' + '\\App_Data\\Unicorn' + ' /E /FFT /W:3 ', { maxBuffer: 5000000 }, function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        //console.log(err);
        cb();
    });
};

function DeleteUnicornConfigs(callback) {
    exec('rmdir \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + '\\App_Config\\Include\\Unicorn /s /q', function (err, stdout, stderr) {
        //return exec('rmdir E:\\uatcd\\App_Config\\Include\\Unicorn /s /q', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        callback();
    });
};

function DeleteAppOfflineJT(cb) {
    exec('del "C:\\Projects\\ACR Sitecore\\ACR_Sitecore_Website\\App_Offline.htm" /s /q /f', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb();
    });
};

function DeleteRobotsTxt(callback) {
    exec('del \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + '\\robots.txt /s /q /f', function (err, stdout, stderr) {
        //return exec('rmdir E:\\uatcd\\App_Config\\Include\\Unicorn /s /q', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        callback();
    });
};

function DeleteWebDavRemote(callback) {
    exec('del \\\\' + gulpConfig.ACRDeployIP + '\\' + gulpConfig.ACRDeployFolder + '\\App_Config\\Include\\Sitecore.WebDAV.config /s /q /f', function (err, stdout, stderr) {
        //return exec('rmdir E:\\uatcd\\App_Config\\Include\\Unicorn /s /q', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        callback();
    });
};

function deleteDeployDirectory() {
    var directory = gulpConfig.webRoot + "/**";
    console.log(directory)
    return del([
        directory
    ], { 'force': true });
};

function CopyUnicorns() {
    return gulp.src('../../Unicorn/ACR Helix/**/*.yml')
        .pipe(gulp.dest(gulpConfig.webRoot + "/App_Data/Unicorn/ACR Helix"));
}

function DeleteUnicorns() {
    var directory = gulpConfig.webRoot + "/App_Data/Unicorn/**";
    console.log(directory)
    return del([
        directory
    ], { 'force': true });

}

function DeleteConfigFolder() {
    var directoryU = gulpConfig.webRoot + "/App_Config/Include/Unicorn";
    var directoryZ = gulpConfig.webRoot + "/App_Config/Include/zzz";
    return del([
        directoryU, directoryZ
    ], { 'force': true });

}

function DeleteUnnessaryFolder() {
    var directoryU = gulpConfig.webRoot + "/Bin/App_Config/";   
    return del([
        directoryU
    ], { 'force': true });

}

function cleanArtifacts() {
    return del([
        'C:\\Projects\\ACR Sitecore\\Artifacts\\DEV-JT\\**\*'
    ], { force: true });
}

function jtcdpowershell(cb) {
    exec(
        "Powershell.exe  -executionpolicy remotesigned -File  clean-jt-cd.ps1",
        function (err, stdout, stderr) {
            console.log(stdout);
            cb(err);
        }
    );
}

function StopACRHelixApplicationPool(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd stop apppool /apppool.name:ACRHelix', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb();
    });
};

function StopACRHelixApplicationPoolJtAuth(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd stop apppool /apppool.name:ACR-Auth', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb();
    });
}

function StopACRHelixApplicationPoolDM(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd stop apppool /apppool.name:ACRHelixAppPool', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb();
    });
};

function StartACRHelixApplicationPool(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd start apppool /apppool.name:ACRHelix', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb(err);
    });
};

function StartACRHelixApplicationPoolJtAuth(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd start apppool /apppool.name:ACR-Auth', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb(err);
    });
}

function StartACRHelixApplicationPoolDM(cb) {
    exec('c:\\windows\\system32\\inetsrv\\appcmd start apppool /apppool.name:ACRHelixAppPool', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        console.log(err);
        cb(err);
    });
};

function Publish_Site(location) {
    console.log('Starting Publish.  Location: ' + location + '  BuildConfig: ' + currentBuildConfig);
    return gulp.src(location)
        //.pipe(debug())
        .pipe(foreach(function (stream, file) {
            console.log(file);
            return stream
                .pipe(debug({ title: "Building project:" }))
                .pipe(msbuild({
                    targets: ["Build"],
                    errorOnFail: true,
                    configuration: currentBuildConfig,
                    logCommand: true,
                    verbosity: "minimal",
                    stdout: true,
                    maxcpucount: 1,
                    toolsVersion: "auto", //15.0, //
                    properties: {
                        TargetFrameworkSDKToolsDirectory: "C:\\msbuildtools",
                        DeployOnBuild: "true",
                        DeployDefaultTarget: "WebPublish",
                        WebPublishMethod: "FileSystem",
                        DeleteExistingFiles: "false",
                        publishUrl: gulpConfig.webRoot,
                        _FindDependencies: "false",
                        //consoleloggerparameters: "ErrorsOnly",
                        nr: "false"
                    }
                })
                );
        }))
}

gulp.task("Publish-Custom", function () {
    return Publish_Site(CustomPath);
});

function PublishFoundationProjects() {
    return Publish_Site("./Foundation/**/*.csproj");
};

function PublishFeatureProjects() {
    return Publish_Site("./Feature/**/*.csproj");
};

function PublishBulletinProject() {
    return Publish_Site("./Feature/Bulletin/**/*.csproj");
}

function PublishProjectProjects() {
    return Publish_Site("./Project/**/*.csproj");
};

function PublishMicrositeProjects() {
    return Publish_Site('./Microsites/**/*.csproj');
};

function UpdateARCJsBundle(cb) {
    //BundleMinifyAssets = false;

    var siteBundle = ['Project\\ACRHelix\\js\\jquery-2.2.0.min.js',
        'Project\\ACRHelix\\js\\jquery.touchSwipe.min.js',
        'Project\\ACRHelix\\js\\es6\\dist\\acr-main.min.js',
        'Project\\ACRHelix\\js\\es6\\dist\\acr-bulletin.min.js',
        'Project\\ACRHelix\\js\\fixCss.js',
        'Project\\ACRHelix\\js\\shopping-cart\\cart-count.js',
        'Project\\ACRHelix\\js\\social\\social-sharing.js',
        'Project\\ACRHelix\\js\\cookie-bot\\cookiebotevents.js'
    ];

    var dsiBundle = [
        'Project\\ACRHelix\\js\\jquery-2.2.0.min.js',
        'Project\\ACRHelix\\js\\jquery.touchSwipe.min.js',
        'Project\\ACRHelix\\js\\es6\\dist\\acr-main.min.js',
        'Project\\ACRHelix\\js\\fixCss.js',
        'Project\\ACRHelix\\js\\shopping-cart\\cart-count.js',
        'Project\\ACRHelix\\js\\social\\social-sharing.js',
        'Project\\ACRHelix\\js\\dsi\\dsi-main.js',
        'Project\\ACRHelix\\js\\cookie-bot\\cookiebotevents.js'
    ];
    buildJSLib(dsiBundle, 'dsi-bundle.min.js', 'Project\\ACRHelix\\js\\bundles');
    buildJSLib(siteBundle, 'acr-bundle.min.js', 'Project\\ACRHelix\\js\\bundles');
    cb();
};

function UpdateAcrCssBundle(cb) {
    var bundle = ['Project\\ACRHelix\\css\\acr-main.css', 'Project\\ACRHelix\\css\\cookie-bot\\acr-cookie-bot-overrides.css'];

    minifyBundleCss(bundle, 'acr-css-bundle.min.css', 'Project\\ACRHelix\\css\\bundles');
    cb();
};

function UpdateDsiCssBundle(cb) {
    var dsiBundle = ['Project\\ACRHelix\\css\\acr-main.css', 'Project\\ACRHelix\\css\\dsi-main.css', 'Project\\ACRHelix\\css\\cookie-bot\\acr-cookie-bot-overrides.css'];

    minifyBundleCss(dsiBundle, 'dsi-css-bundle.min.css', 'Project\\ACRHelix\\css\\bundles');
    cb();
};

function minifyBundleCss(cssFileNames, nameOfBundle, destination) {
    return gulp.src(cssFileNames)
        //.pipe($.sourcemaps.init())
        .pipe(concat(nameOfBundle))
        .pipe(gulpIf(BundleMinifyAssets, minifyCss({ compatibility: 'ie8' })
            .on('error', e => { console.log(e); })
        ))
        //.pipe(gulpIf(!PRODUCTION, $.sourcemaps.write()))
        .pipe(gulp.dest(destination));
}

function buildJSLib(libBundleArray, nameOfBundle, destination) {
    return gulp.src(libBundleArray)
        .pipe(concat(nameOfBundle))
        //.pipe(uglify().on('error', e => { console.log(e); }))
        .pipe(gulpIf(BundleMinifyAssets, uglify()
            .on('error', e => { console.log(e); })
        ))
        //.pipe($.if(!PRODUCTION, $.sourcemaps.write()))
        .pipe(gulp.dest(destination));
}

function CopyCSS() {
    return gulp.src('./Project/ACRHelix/css/**/*.css')
        .pipe(gulp.dest(gulpConfig.webRoot + "\\css"));
}

function MinifyCss() {
    var cssPath = gulpConfig.webRoot + "\\css\\**\\*.css";
    var exclude = '!' + gulpConfig.webRoot + "\\css\\**\\*.min.css";
    console.log(cssPath);
    return gulp.src(cssPath)
        .pipe(gulpIf(BundleMinifyAssets, minifyCss({ compatibility: 'ie8' })))
        .pipe(gulp.dest(gulpConfig.webRoot + "\\css"));
};

function MinifyJs(cb) {
    //gulpConfig.webRoot = "C:\\inetpub\\wwwroot\\ACRHelix\\Website";
    var jsPath = gulpConfig.webRoot + "\\js\\**\\*.js";
    var noMinifyJs = '!' + gulpConfig.webRoot + "\\js\\**\\*.min.js";
    console.log("minifying js in: " + jsPath + ", copying to " + gulpConfig.webRoot + "\\js");
    /*
        pump([
            gulp.src([jsPath, noMinifyJs]),
            uglify(),
            gulp.dest(gulpConfig.webRoot + "\\js")
        ], cb);*/
    return gulp.src([jsPath, noMinifyJs])
        .pipe(uglify().on('error', e => { console.log(e); }))
        .pipe(gulp.dest(gulpConfig.webRoot + "\\js"));
};

var config = {
    webpack: {
        mode: BUILD_PROD_JS ? "production" : "development",
        devtool: "",//PRODUCTION ? "" : "inline-source-map",
        output: {
            filename: '[name].min.js',
        },
        module: {
            rules: [
                {
                    test: /.js$/,
                    exclude: /(node_modules\/(?!(@hilemangroup|bootstrap)))/,
                    use: [
                        {
                            loader: "babel-loader",
                            options: {
                                presets: ["@babel/preset-env"]
                            }
                        }
                    ]
                }
            ]
        },
        optimization: {
            minimize: true,
        },
        plugins: [
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery",
                "window.jQuery": "jquery"
            })
        ],
        externals: {
            jquery: "jQuery"
        }//,
        // optimization: {
        //   splitChunks: {
        //     //https://webpack.js.org/plugins/split-chunks-plugin/#optimization-splitchunks
        //     chunks: 'all',
        //  }
        // }
    },
    handlebars: {
        settings: {
            ignorePartials: true,
            batch: ['src/includes'],
            partials: null
        },
        variables: {
            PRODUCTION: PRODUCTION,
            TODAYS_DATE: todaysDate,
            placeholder: `https://via.placeholder.com/`
        }
    }
};

var todaysDate = (function () {
    var d = new Date(),
        yy = d.getFullYear(),
        day = d.getDate(),
        mm = d.getMonth() + 1;

    if (mm < 10) {
        mm = '0' + mm.toString();
    }

    if (day < 10) {
        day = '0' + day.toString();
    }

    return yy + '.' + mm + '.' + day;
})();

//NOTE: update this  to the real dest when all is Kosher
var DEST = PRODUCTION ? './Project/ACRHelix/' : './test/';

function buildSCSS(pathTo, dest) {
    return gulp.src(pathTo)
        //.pipe(debug())
        .pipe(sourcemaps.init())
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ["last 2 versions", "ie >= 9", "ios >= 10"],
            remove: false
        }))
        //NOT MINIFYING FOR LEGIBILITY
        .pipe(gulpIf(PRODUCTION, cleanCss({
            compatibility: "ie9",
            debug: true
        }, function (details) {
            //console.log(details.name + ': ' + details.stats.originalSize);
            //console.log(details.name + ': ' + details.stats.minifiedSize);
        })))
        .pipe(gulpIf(!PRODUCTION, sourcemaps.write()))
        .pipe(gulp.dest(dest));
}

function buildAllCSS() {
    return buildSCSS('./Project/ACRHelix/scss/src/**/*.{css,scss}', DEST + 'css/');
    //done();
}

function buildJS() {
    // Combine JavaScript into one file

    console.log('building js, production: ' + PRODUCTION)
    console.log('prod js dest: ' + DEST + 'js/')

    //console.log(config.webpack)

    return gulp.src([
        './Project/ACRHelix/js/es6/src/acr-main.js',
        './Project/ACRHelix/js/es6/src/acr-bulletin.js'
        //,'./src/microsites/accred/js/**/*.js'
    ])
        .pipe(named())
        .pipe(sourcemaps.init())
        .pipe(webpackStream(config.webpack, webpack))
        .pipe(gulpIf(!PRODUCTION, sourcemaps.write('.')))
        .pipe(gulp.dest(DEST + 'js/es6/dist'));
}

gulp.task('build-for-deploy',
    gulp.series(buildAllCSS,
        buildJS
        , UpdateAcrCssBundle,
        UpdateDsiCssBundle,
        UpdateARCJsBundle
    ));

gulp.task('fix-csproj-files',
    gulp.series(function () {
        return gulp.src("./**/*.csproj").pipe(replace('<CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>', '')).pipe(gulp.dest('./'))
    }
    ));
