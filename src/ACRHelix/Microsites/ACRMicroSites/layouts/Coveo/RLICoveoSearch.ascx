<%@ Control Language="c#" AutoEventWireup="true" Inherits="Coveo.UI.CoveoSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="Coveo.UI" %>
<%@ Register TagPrefix="coveoui" Namespace="Coveo.UI.Controls" Assembly="Coveo.UIBase" %>


<div class="row">
    <div id="coveo-search-area">
       <aside class="searchbar">
           <div class="search-outer">
            <section class="facetHeader">
                <h2>SEARCH THE CATALOG</h2>
                <!-- Move searchbox here -->
            </section>
            <!-- move facets here -->
			</div>
        </aside>
        <section class="content-with-sidebar">
            <div id="content_1_divBanner" class="banner outerContainer banner-fifth">
                <div class="innerContainer">
                    <div class="element">
                        <h1>RLI Catalog
                        </h1>
                    </div>
                </div>
            </div>
            <!-- When customizing this component, ensure to use "Coveo.$" instead of the regular jQuery "$" to
     avoid any conflicts with Sitecore's Page Editor/Experience Editor.  -->
            <coveoui:ErrorSummary runat="server" />
            <coveoui:WhenConfigured runat="server">
                <script type="text/javascript" src="/Coveo/js/cultures/<%= Model.CultureName %>.js"></script>
                <script type="text/javascript">
                    Coveo.$(function() {
                        //CoveoForSitecore.componentsOptions = <%= Model.GetJavaScriptInitializationOptions() %>;
                        var options = <%= Model.GetJavaScriptInitializationOptions() %>;
                        //replace static filter dates with todays date
                        var todaysDate = new Date();
                        var mm = (todaysDate.getMonth() + 1);
                        var dd =  todaysDate.getDate();
                        if(mm < 10){
                            mm = '0' + mm;
                        }
                        if(dd < 10){
                            dd = '0' + dd;
                        }			
                        var dateString = todaysDate.getFullYear() + '/' + mm + '/' + dd + '@00:00:00';	

                        //web display is checked
                        var xDisplay = '(@<%= ToCoveoFieldName("Web Display", false) %>=="1") ';
                        //is an rli product
                        var isRLI = '(@<%= ToCoveoFieldName("HasRLI", false) %>=="1") ';

                        var template = '@<%= ToCoveoFieldName("template", false) %>'.replace('ftemplate','fz95xtemplate');			
                        var xTemplate = '(' + template + '=="62BEEA1D6B794E0CA98FE337E321DBBE")';

                        var xWebStart = '(@<%= ToCoveoFieldName("productstubwebdisplaystartdate", false) %><=' + dateString +')';
                        var xWebEnd = '(@<%= ToCoveoFieldName("productstubwebdisplayenddate", false) %>>=' + dateString +')';
                        var xMeetingStart = '(@<%= ToCoveoFieldName("productstubmeetingstartdate", false) %>>=' + dateString +')';
                        var xFilter = '('  + xDisplay + isRLI + xTemplate + xWebStart + xWebEnd + xMeetingStart + ')'; 
			
                        options.filterExpression = xFilter;		
                        CoveoForSitecore.componentsOptions = options;
                    });
                </script>
                <!-- This hidden input is required to bypass a problem with the Enter key causing a form submission
         if the form has exactly one text field, or only when there is a submit button present. -->
                <input type="text" class="fix-submit" />
                <div id="<%= Model.Id %>"
                    class="CoveoSearchInterface"
                    data-design='new'
                    data-loading-animation="false"
                    data-enable-history="<%= Model.EnableHistory %>"
                    data-results-per-page="<%= Model.ResultsPerPage %>"
                    data-excerpt-length="<%= Model.ExcerptLength %>"
                    data-hide-until-first-query="<%= Model.HideUntilFirstQuery %>"
                    data-auto-trigger-query="<%= Model.AutoTriggerQuery %>"
                    data-enable-automatic-responsive-mode="false"
                    <% if (Model.IsMaximumAgeSet)
                  { %>
                    data-maximum-age="<%= Model.MaximumAge %>"
                    <% } %>
                    <% if (Model.UseCustomQueryPipeline)
                  { %>
                    data-pipeline="<%: Model.QueryPipelineName %>"
                    <% } %>>

                    <% if (Model.AnalyticsEnabled)
                      { %>
                    <div class="CoveoAnalytics"
                        data-anonymous="<%= Model.IsUserAnonymous %>"
                        data-endpoint="<%= Model.GetAnalyticsEndpoint() %>"
                        data-search-hub="<%= Model.GetAnalyticsCurrentPageName() %>"
                        data-send-to-cloud="<%= Model.CoveoAnalyticsEnabled %>">
                    </div>
                    <% } %>
                    <div class="coveo-main-section">
                        <% if (Model.DisplayTabs)
                          { %>
                        <div class="coveo-tab-section coveo-placeholder-fix" style="display: none">
                            <sc:Placeholder Key="coveo-tabs" runat="server"></sc:Placeholder>
                        </div>
                        <% } %>
                        <% if (Model.DisplayFacets)
                          { %>
                        <div class="coveo-facet-column">
                            <% if (Model.DisplayLogo)
                              { %>
                            <div class="coveo-logo"></div>
                            <% } %>
                            <sc:Placeholder Key="coveo-facets" runat="server"></sc:Placeholder>
                            &nbsp;
                        </div>
                        <% } %>
                        <div class="coveo-results-column">
                            <% if (Model.DisplaySearchbox)
                              { %>
                            <div class="CoveoSearchbox CoveoSearchPageSearchbox"
                                data-auto-focus="<%= Model.AutoFocus %>"
                                data-enable-lowercase-operators="<%= Model.EnableLowercaseOperators %>"
                                data-enable-partial-match="<%= Model.EnablePartialMatch %>"
                                data-partial-match-keywords="<%= Model.PartialMatchKeywords %>"
                                data-partial-match-threshold="<%= Model.PartialMatchThreshold %>"
                                data-enable-question-marks="<%= Model.EnableQuestionMarks %>"
                                data-enable-wildcards="<%= Model.EnableWildcards %>"
                                <% if (Model.EnableOmnibox)
                              { %>
                                data-enable-omnibox="true"
                                data-omnibox-timeout="<%= Model.OmniboxTimeout %>"
                                data-enable-field-addon="<%= Model.OmniboxEnableFieldAddon %>"
                                data-enable-simple-field-addon="<%= Model.OmniboxEnableSimpleFieldAddon %>"
                                data-enable-top-query-addon="<%= Model.OmniboxEnableTopQueryAddon %>"
                                data-enable-reveal-query-suggest-addon="<%= Model.OmniboxEnableRevealQuerySuggestAddon %>"
                                data-enable-query-extension-addon="<%= Model.OmniboxEnableQueryExtensionAddon %>"
                                <% } %>
                                <% if (Model.IsSearchAsYouTypeEnabled)
                              { %>
                                data-enable-search-as-you-type="true"
                                data-search-as-you-type-delay="<%= Model.SearchboxSuggestionsDelay %>"
                                <% } %>>
                            </div>
                            <% } %>
                            <% if (Model.DisplayBreadcrumb)
                              { %>
                            <div class="CoveoBreadcrumb"></div>
                            <% } %>
                            <div class="coveo-results-header">
                                <div class="coveo-summary-section">
                                    <% if (Model.DisplayDidYouMean)
                                      { %>
                                    <div class="CoveoDidYouMean" style="font-size: 12px"
                                        data-enable-auto-correction="<%= Model.EnableDidYouMeanAutoCorrection %>">
                                    </div>
                                    <% } %>
                                    <% if (Model.DisplayQuerySummary)
                                      { %>
                                    <span class="CoveoQuerySummary"
                                        data-enable-search-tips="<%= Model.QuerySummaryEnableSearchTips %>"
                                        data-only-display-search-tips="<%= Model.QuerySummaryOnlyDisplaySearchTips %>"></span>
                                    <% } %>
                                    <% if (Model.DisplayQueryDuration)
                                      { %>
                                    <span class="CoveoQueryDuration"></span>
                                    <% } %>
                                </div>
                                <% if (Model.DisplaySorting)
                                  { %>
                                <div class="coveo-sort-section">
                                    <sc:Placeholder Key="coveo-sorts" runat="server"></sc:Placeholder>
                                </div>
                                <% } %>
                            </div>
                            <div class="CoveoHiddenQuery"></div>
                            <% if (Model.DisplayErrorReport)
                              { %>
                            <div class="CoveoErrorReport"></div>
                            <% } %>

                            <% if (Model.DisplayResultList)
                              { %>
                            <% if (Model.DisplayTopPager)
                              { %>
                            <div class="CoveoPager" data-number-of-pages="5"
                                data-max-number-of-pages="100"
                                data-enable-navigation-button="<%= Model.EnablePagerNavigationButton %>">
                            </div>
                            <% } %>
                            <ul class="pagination_content CoveoResultList" data-wait-animation="fade"
                                data-enable-infinite-scroll="<%= Model.EnableInfiniteScroll %>"
                                data-infinite-scroll-page-size="<%= Model.InfiniteScrollPageSize %>">

                                <script class="result-template" type="text/underscore">
                                  <li class="CoveoResult">
                                    <div class="catalog-item clearfix">
										<h4 class="product-title only-coveo-tablet-mobile"><a  class="fullwidth link-external" href="{{= raw['<%= ToCoveoFieldName("producturl", false) %>'] }}">{{= raw['<%= ToCoveoFieldName("Long Name", false) %>'] }}</a></h4>
                                        <div class="image">
                                            <img style="max-width:100px" alt="{{= raw['<%= ToCoveoFieldName("Long Name", false) %>'] }} image" src="{{= raw['<%= ToCoveoFieldName("productstublargeimageurl", false) %>'] }}">
                                        </div>
                                        <!-- info -->
                                        <div class="info">
                                            <h4 class="product-title only-coveo-desktop"><a  class="fullwidth link-external" href="{{= raw['<%= ToCoveoFieldName("producturl", false) %>'] }}">{{= raw['<%= ToCoveoFieldName("Long Name", false) %>'] }}</a></h4>
                                            <span class="coveo-short-description only-coveo-desktop-tablet">{{= raw['<%= ToCoveoFieldName("Short Description", false) %>'] }}</span>
                                            <div class="btns-area only-coveo-desktop-tablet">
                                                <a class="link-attention" href="{{= raw['<%= ToCoveoFieldName("producturl", false) %>'] }}">View details</a>
                                            </div>
                                        </div>
                                        <!-- end info -->
                                        <div class="details">
                                            <strong class="product-price-title">Price Details</strong>
                                            <h5 class="header-fifth">Nonmember: <span class="var-list-price">${{= raw['<%= ToCoveoFieldName("List Price", false) %>'] }}</span></h5>
                                            <h5 class="header-fifth member-price">Member: <span class="var-member-price"><span>${{= raw['<%= ToCoveoFieldName("Member Price", false) %>'] }}</span></span></h5>
                                            <h5 class="header-fifth">MIT: <span class="var-mit-price">${{= raw['<%= ToCoveoFieldName("MIT Price", false) %>'] }}</span></h5>
                                            <p>Availability</p>
                                            <span class="var-product-availability{{= raw['<%= ToCoveoFieldName("productstubstockstatuscss", false) %>'] }}">{{= raw['<%= ToCoveoFieldName("productstubstockstatus", false) %>'] }}
                                            </span>
											<div class="btns-area only-coveo-mobile">
                                                <a class="link-attention" href="{{= raw['<%= ToCoveoFieldName("producturl", false) %>'] }}">View details</a>
                                            </div>
                                 <%--   <div class="debug" style="display:none" >IsMeeting:{{= raw['<%= ToCoveoFieldName("IsMeeting", false) %>'] }}
                                   Meeting Date:{{= raw['<%= ToCoveoFieldName("meetingmeetingdisplaydate", false) %>'] }}
                                     Name:{{= raw['<%= ToCoveoFieldName("Long Name", false) %>'] }}
									 datauri:{{= raw['<%= ToCoveoFieldName("datauri", false) %>'] }}
									 </div>--%>
                                        </div>
                                    </div>
                                </li>
                                </script>

                            </ul>
                            <% if (Model.DisplayBottomPager)
                              { %>
                            <div class="CoveoPager" data-number-of-pages="5"
                                data-max-number-of-pages="100"
                                data-enable-navigation-button="<%= Model.EnablePagerNavigationButton %>">
                            </div>
                            <% } %>
                            <% } %>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    Coveo.$(function() {
                        Coveo.$(".CoveoSearchInterface").on("afterComponentsInitialization", function(){
                            Coveo.$(".CoveoSearchInterface").on('buildingQuery', function (e, data) {
                                if(data.queryBuilder.expression.parts.length > 0){					
                                    if(data.queryBuilder.expression.parts[0].indexOf(',') >= 0 ){					
                                        data.queryBuilder.expression.parts[0] = data.queryBuilder.expression.parts[0].replace(/,/g,'');					
                                    }					
                                }
								data.queryBuilder.sortCriteria = "<%= ToCoveoFieldName("IsMeeting") %> descending, <%= ToCoveoFieldName("productstubmeetingstartdate") %> ascending, <%= ToCoveoFieldName("Long Name") %> ascending";
							});
                            Coveo.$(".CoveoSearchInterface").on("doneBuildingQuery", function(e, args) {
                                //maybe add qre for product name match
                                var expression = args.queryBuilder.expression.build();                                
                                if(expression != null)
                                {			 
                                    expression = '<%= ToCoveoFieldName("Long Name") %> = ' + expression;
                                    var modifier = '100';			 
                                    var qre = "$qre(expression:'" + expression + "', modifier:'" + modifier + "')";		 
                                    args.queryBuilder.advancedExpression.add(qre);
                                 }
                            });

                            Coveo.$(".CoveoSearchInterface").on('deferredQuerySuccess', function (e, data) {	
                                Coveo.$(".searchedFor").detach();
                                var hash = window.location.hash;
                                var term = '';
                                if(hash.indexOf('q=') > 0){
                                    var and = hash.indexOf('&');

                                    if(and > 0){
                                        term = hash.substring(3,and);
                                    }else{
                                        term = hash.substring(3);
                                    }
                                    var searchedString = '<h4 class="searchedFor">You searched for <a href="#">"' + decodeURIComponent(term) + '"</a></h4>';
                                    Coveo.$(".coveo-summary-section").prepend(searchedString);
                                }


                                //show pager first last links
                                var pager = Coveo.$('.coveo-pager-list');					
                                var pages = Coveo.$('.CoveoQuerySummary').find('.coveo-highlight');
                                var pc = [];
                                var pcTotal = 1;
					
                                pages.each(function(){
                                    pc.push(Coveo.$(this).text().replace(',',''));
                                });
					
                                if(pc.length === 3){
                                    var first = pc[0];
                                    pcTotal = pc[2];
					
                                    var totalPages = Math.ceil(pcTotal / 10);
					
                                    if(totalPages > 100){
                                        totalPages = 100;
                                    }
					
                                    pager.each(function(){		
                                        if (pc[1] != pc[2]){
                                            if(pc[1] != 1000){
                                                Coveo.$(this).append('<li style="border:0" class="coveo-pager-anchor coveo-pager-list-item"><a onclick="lastPage()" title="Last"><span>Last</span></a></li>');
                                            }
                                        }
                                        if(first > 1){
                                            Coveo.$(this).prepend('<li style="border:0" class="coveo-pager-anchor coveo-pager-list-item"><a onclick="firstPage()" title="First"><span>First</span></a></li>');
                                        }
					
                                    });
					
                                }//end pager first last links

                                //fix tabs for personify
                                Coveo.$(".catalog-item").each(function(){						
                                    Coveo.$(this).find('a').each(function(){						
                                        var href = Coveo.$(this).attr('href');
                                        href = href.replace('TabID=55','TabID=294');
                                        href = href.replace('//preview.acr.org', '//www.acr.org');
                                        if (window.location.host == 'preprod.radiologyleaders.org') {
                                            href = href.replace('//shop.acr.org', '//shopqa.acr.org');
                                        }
                                        Coveo.$(this).attr('href',href);
                                    });						
                                });

                                
                                //fix tabs for personify
                                Coveo.$(".catalog-item").each(function(){						
                                    Coveo.$(this).find('a').each(function(){						
                                        var href = Coveo.$(this).attr('href');
                                        href = href.replace('//www.acraccreditation.org','//www.acr.org');
                                        Coveo.$(this).attr('href',href);
                                    });						
                                });

                                //hide prices for bad records
                                Coveo.$('.details').each(function(){
                                    var memp = Coveo.$(this).find('.var-member-price');
                                    var mitp = Coveo.$(this).find('.var-mit-price');

                                    if(memp.text().trim().length == 1){
                                        memp.parent().hide();
                                    }
                                    if(mitp.text().trim().length == 1){
                                        mitp.parent().hide()
                                    }
                                });

                                Coveo.$('.custom-no-results').detach();
					
                                var noResults = Coveo.$('.coveo-query-summary-no-results-string');
                                if(noResults.length > 0){
                                    noResults.hide();
                                    Coveo.$('.coveo-query-summary-cancel-last').hide();
                                    Coveo.$('.CoveoQuerySummary').find('ul').hide();
                                    Coveo.$('.coveo-query-summary-search-tips-info').hide();
                                    Coveo.$('.CoveoResultList').hide();
                                    Coveo.$('.coveo-summary-section').append('<p class="custom-no-results" style="font-size:12px;margin-top:10px">Sorry, no results could be found for your query. Please revise your search and try again.</p>')
                                    if(Coveo.$('.coveo-active').length == 0){
                                        Coveo.$('.newCoveoSearchBoxHolder').removeClass('newCoveoSearchBoxHolder1');
                                    }
                                }else{
                                    Coveo.$('.newCoveoSearchBoxHolder').addClass('newCoveoSearchBoxHolder1');
                                }
					
                                if(Coveo.$('.CoveoDidYouMean').is(':visible')){
                                    Coveo.$('.CoveoQuerySummary').css('margin-top','0px');
                                }else{
                                    Coveo.$('.CoveoQuerySummary').css('margin-top','20px');
                                }

                            });
                        });
                        Coveo.$('#<%= Model.Id %>').coveoForSitecore('init', CoveoForSitecore.componentsOptions);
                        //move coveo items
                        Coveo.$(".CoveoFacet").detach().appendTo(".search-outer");
                        Coveo.$(".CoveoSearchbox").detach().appendTo(".facetHeader");		        
                        //hide coveo items
                        Coveo.$(".coveo-facet-column").hide();		
                    });

                    //paging methods
                    function firstPage(){
                        //alert('first page');		
                        var param = getParameterByName('first');		
                        var hash = window.location.hash.replace('first=' + param,'first=0');
                        window.location.hash = hash;
		
                    }		
                    function lastPage(){
                        var param = getParameterByName('first');
		
                        var pages = Coveo.$('.CoveoQuerySummary').find('.coveo-highlight');
                        var pc = [];
                        var pcTotal = 1;
					
                        pages.each(function(){
                            pc.push(Coveo.$(this).text().replace(',',''));
                        });
					
                        if(pc.length === 3){
                            var first = pc[0];
                            pcTotal = pc[2];
					
                            var totalPages = Math.ceil(pcTotal / 10);
					
                            if(totalPages > 100){
                                totalPages = 100;
                            }
					
		
                            if(param == null){
                                if(window.location.hash.length > 1){
                                    var hash = '&first=' + (totalPages -1)*10;
                                    window.location.hash += hash;
                                }else{
                                    window.location.hash = 'first=' + (totalPages -1)*10;
                                }
                            }else{
                                var param = getParameterByName('first');		
                                var hash = window.location.hash.replace('first=' + param,'first=' + (totalPages -1)*10);
                                window.location.hash = hash;		
                            }
                        }
                    }		
                    function getParameterByName(name) {
                        var url = window.location.hash;
                        name = name.replace(/[\[\]]/g, "\\$&");
                        var regex = new RegExp("[#&]" + name + "(=([^&#]*)|&|#|$)"),
                            results = regex.exec(url);
                        if (!results) return null;
                        if (!results[2]) return '';
                        return decodeURIComponent(results[2].replace(/\+/g, " "));
                    }
                    //end paging methods
					
					$('.searchbar').on('click','.facetHeader > h2',function() {
					  //only in mobile
					  if ($(window).width() <= 640) {
						if ($('.CoveoFacet').hasClass('openedFacet')) {
						  $(this).removeClass('openedFacet');
						  $('.CoveoFacet').removeClass('openedFacet');
							$('.searchbar').removeClass('opened-search');
							$('body').removeClass('opened-search');
						} else {
						  $(this).addClass('openedFacet');
						  $('.CoveoFacet').addClass('openedFacet');
						  $('.searchbar').addClass('opened-search');
						  $('body').addClass('opened-search');
						}
					  }
					 });
                </script>
            </coveoui:WhenConfigured>

            <% if (Model.HasErrors)
              { %>
            <div class="CoveoServerError">
                <h3><%= Model.Labels[LocalizedStringKeys.FRIENDLY_SEARCH_UNAVAILABLE_TITLE] %></h3>
                <h4><%= Model.Labels[LocalizedStringKeys.FRIENDLY_SEARCH_UNAVAILABLE_DETAIL] %></h4>
            </div>

            <% if (SitecoreContext.IsEditingInPageEditor())
              { %>
            <script type="text/javascript">
                Coveo.$(function() {
                    Coveo.PageEditorDeferRefresh.triggerUpdate();
                });
            </script>
            <% } %>
            <% } %>
        </section>
    </div>
</div>
