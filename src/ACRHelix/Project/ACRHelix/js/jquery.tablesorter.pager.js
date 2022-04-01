(function($) {
	$.extend({
		tablesorterPager: new function() {
			
			var _ = this;
			
			function updatePageDisplay(c) {
				var s = $("."+c.cssPageDisplay,c.container).val((c.page+1) + c.seperator + c.totalPages);	
			}
			
			function setPageSize(table,size) {
				var c = table.config;
				c.size = size;
				c.totalPages = Math.ceil(c.totalRows / c.size);
				c.pagerPositionSet = false;
				moveToPage(table);
				fixPosition(table);
			}
			
			function fixPosition(table) {
				var c = table.config;
				if(!c.pagerPositionSet && c.positionFixed) {
					var c = table.config, o = $(table);
					if(o.offset) {
						c.container.css({
							top: o.offset().top + o.height() + 'px',
							position: 'absolute'
						});
					}
					c.pagerPositionSet = true;
				}
			}
			
			function moveToFirstPage(table) {
				var c = table.config;
				c.page = 0;
				moveToPage(table);
			}
			
			function moveToLastPage(table) {
				var c = table.config;
				c.page = (c.totalPages-1);
				moveToPage(table);
			}
			
			function moveToNextPage(table) {
				var c = table.config;
				c.page++;
				if(c.page >= (c.totalPages-1)) {
					c.page = (c.totalPages-1);
				}
				moveToPage(table);
			}
			
			function moveToPrevPage(table) {
				var c = table.config;
				c.page--;
				if(c.page <= 0) {
					c.page = 0;
				}
				moveToPage(table);
			}
						
			
			function moveToPage(table) {
				var c = table.config;
				if(c.page < 0 || c.page > (c.totalPages-1)) {
					c.page = 0;
				}
				
				renderTable(table,c.rowsCopy);
			}
			
			function renderTable(table,rows) {
				
				var c = table.config;
				var l = rows.length;
				var s = (c.page * c.size);
				var e = (s + c.size);
				if(e > rows.length ) {
					e = rows.length;
				}
				
				
				var tableBody = $(table.tBodies[0]);
				
				// clear the table body
				
				$.tablesorter.clearTableBody(table);
				
				for(var i = s; i < e; i++) {
					
					//tableBody.append(rows[i]);
					
					var o = rows[i];
					var l = o.length;
					for(var j=0; j < l; j++) {
						
						tableBody[0].appendChild(o[j]);

					}
				}
				
				fixPosition(table,tableBody);
				
				$(table).trigger("applyWidgets");
				
				if( c.page >= c.totalPages ) {
        			moveToLastPage(table);
				}
				
				updatePageDisplay(c);
			}
			
			
			var defaultStartSize = ($(window).width() > 1024) ? 
					{num:30,device:'desktop'} : {num:10,device:'mobile'};
			
			function buildPager(config){
				
				var mSelected="",
					dSelected="";
				
				if( defaultStartSize.device ==="desktop" ){
					dSelected='selected="selected"';
				}else{
					mSelected='selected="selected"';
				}
				
				var pagerHTML = '<div class="table-pager-inner">'+
					'<span class="pager-btn '+ config.cssFirst + '">First</span>'+
					'<span class="pager-btn '+ config.cssPrev + '">Prev</span>'+
					'<input class="pagedisplay" type="text" readonly >'+
					'<span class="pager-btn '+ config.cssNext + '">Next</span>'+
					'<span class="pager-btn '+ config.cssLast + '">Last</span>'+
					'<div class="page-size-outer">Page Size: <select class="pagesize">'+
						'<option '+mSelected+' value="10">10</option>'+
						'<option value="20">20</option>'+
						'<option '+dSelected+' value="30">30</option>'+
						'<option value="40">40</option>'+
					'</select></div></div>';
				
				$(config.container).html(pagerHTML);
					
			}
			
			this.appender = function(table,rows) {
				
				var c = table.config;
				
				c.rowsCopy = rows;
				c.totalRows = rows.length;
				c.totalPages = Math.ceil(c.totalRows / c.size);
				
				renderTable(table,rows);
			};
			
			
			this.defaults = {
				size: defaultStartSize.num,
				offset: 0,
				page: 0,
				totalRows: 0,
				totalPages: 0,
				container: null,
				cssNext: 'next-pager-btn',
				cssPrev: 'prev-pager-btn',
				cssFirst: 'first-pager-btn',
				cssLast: 'last-pager-btn',
				cssPageDisplay: 'pagedisplay',
				cssPageSize: 'pagesize',
				seperator: "/",
				positionFixed: true,
				appender: this.appender,
				sizeChangeCallback: null
			};
			
			this.construct = function(settings) {
				
				return this.each(function() {	
					
					var config = $.extend(this.config, $.tablesorterPager.defaults, settings);
					
					var table = this, 
						pager = config.container;
					
					buildPager(config);
					
					$(this).trigger("appendCache");
					
					config.size = parseInt($(".pagesize",pager).val());
					
					$("."+config.cssFirst,pager).click(function() {
						moveToFirstPage(table);
						
					});
					$("."+config.cssNext,pager).click(function() {
						moveToNextPage(table);
						
					});
					$("."+config.cssPrev,pager).click(function() {
						moveToPrevPage(table);
						
					});
					$("."+config.cssLast,pager).click(function() {
						moveToLastPage(table);
						
					});
					$("."+config.cssPageSize,pager).change(function() {
						setPageSize(table,parseInt($(this).val()));
						if (typeof config.sizeChangeCallback === 'function'){
							config.sizeChangeCallback();
						}
					});
				});
			};
			
		}
	});
	// extend plugin scope
	$.fn.extend({
        tablesorterPager: $.tablesorterPager.construct
	});
	
})(jQuery);				