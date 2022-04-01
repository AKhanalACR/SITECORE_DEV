//WARNING this got minified and we somehow lost the original...
//sorry if this ever needs changed its quite complex :-/


export default function scrollInView(parentElem, param) {
	$(parentElem).scrollInView(param);
}


!function(e) {
  "use strict";
  var t = !1,
      r = r || {};
  r = function() {
      function r(r, n) {
          var i = this;
          i.thisInstance = ".scrollID_" + s, e(r).addClass(i.thisInstance.slice(1)), s++, i.parentElem = r, i.hasTouchSwipe = t, i.scrollingEnabled = !1, i.scrolledIndex = 0, i.defaults = {
              startWidth: 1024,
              childItem: ".in-view-item",
              slideWrapper: n.$slideContainer || null,
              btnSpace: 64,
              not: "tabs-evenly-spaced",
              scrollItemAmount: 1,
              breakPointsOnWindow: !0,
              resizeDelay: 100,
              leftBtnClass: "acr-icon icon-arrow-left",
              rightBtnClass: "acr-icon icon-arrow-right",
              minWidth: null,
              columns: [{
                  breakpoint: 359,
                  cols: 1
              }, {
                  breakpoint: 768,
                  cols: 2
              }, {
                  breakpoint: 1024,
                  cols: 3
              }, {
                  breakpoint: 2800,
                  cols: 4
              }],
              buttonsAddedClass: "in-view-btns-added"
          }, i.param = e.extend({}, i.defaults, n), i.parent = e(i.thisInstance), i.slideWrapper = i.parent.find(i.param.slideWrapper), i.slideContainerCssMinWidth = parseFloat(i.slideWrapper.css("min-width")), i.slideContainerUseWidth = "number" == typeof i.param.minWidth ? i.param.minWidth : i.slideContainerCssMinWidth, i.scrolledItems = i.parent.find(i.param.childItem + ":first").parent().find(i.param.childItem).length, i.slideContainerWidth = i.slideWrapper.width() + i.param.btnSpace, i.btnsAdded = !1, i.doFixedScroll = "td" === i.param.childItem, i.tFixedScrollOffset = 1, i.wrapperWidth = 0, i.currElemLeft = 0, i.lastElem = i.slideWrapper.find(i.param.childItem).last(), i.lastElemWidth = i.lastElem.outerWidth(), i.lastElemPos = i.lastElem.position().left, i.fixedItemsToScreen = 0, i.parent.hasClass(i.param.not || "tabs-evenly-spaced") || i.parent.hasClass("table-no-scroll") || (i.parent.addClass("hide-left-btn"), i.slideWrapper.wrap('<div class="in-view-wrapper" />'), i.slideWrapper.css({
              position: "relative"
          }), i.init())
      }
      var s = 0;
      return r
  }(), r.prototype.init = function() {
      var e = this;
      e.resizedScreen(), e.swipePlugin(), e.scrollIt()
  }, r.prototype.getFixedItemsToScreen = function() {
      var t = this;
      t.wrapperWidth = t.parent.find(".in-view-wrapper").width();
      var r = t.param.breakPointsOnWindow ? e(window).width() : t.wrapperWidth;
      if ("number" == typeof t.param.columns) t.fixedItemsToScreen = t.param.columns;
      else if ("object" == typeof t.param.columns)
          for (var s = 0, n = t.param.columns.length, i = t.param.columns; n > s; s++)
              if (r <= i[s].breakpoint) {
                  t.fixedItemsToScreen = i[s].cols;
                  break
              }
      if (t.doFixedScroll) {
          var a = t.wrapperWidth / t.fixedItemsToScreen - t.tFixedScrollOffset;
          t.slideWrapper.css({
              "min-width": "1px",
              width: a * t.scrolledItems + t.scrolledItems + "px",
              "table-layout": "fixed"
          })
      }
  }, r.prototype.changePos = function(t) {
      var r = this;
      if (r.scrollingEnabled) {
          var s = r.doFixedScroll ? r.fixedItemsToScreen : r.param.scrollItemAmount,
              n = r.lastElemPos + r.lastElemWidth - r.currElemLeft < r.wrapperWidth - r.param.btnSpace;
          if ("LEFT" === t.toUpperCase() || "SWIPERIGHT" === t.toUpperCase() ? 0 === r.scrolledIndex ? r.scrolledIndex : r.scrolledIndex <= r.scrolledIndex - r.param.scrollItemAmount ? r.scrolledIndex = 0 : r.scrolledIndex -= r.param.scrollItemAmount : ("RIGHT" === t.toUpperCase() || "SWIPELEFT" === t.toUpperCase()) && (!n || r.doFixedScroll) && (r.scrolledIndex >= r.scrolledItems - s ? r.scrolledIndex : r.scrolledIndex += r.param.scrollItemAmount), r.currElemLeft = r.parent.find(r.param.childItem).eq(r.scrolledIndex).position().left, n = r.lastElemPos + r.lastElemWidth - r.currElemLeft < r.wrapperWidth - r.param.btnSpace, r.doFixedScroll && 0 !== r.currElemLeft && (r.currElemLeft += r.tFixedScrollOffset), r.slideWrapper.css("transform", "translate3d(" + -1 * r.currElemLeft + "px, 0px, 0px)"), r.parent.removeClass("hide-right-btn hide-left-btn"), 0 === r.scrolledIndex && r.parent.addClass("hide-left-btn"), r.doFixedScroll ? r.scrolledIndex === r.scrolledItems - s && r.parent.addClass("hide-right-btn") : n && r.parent.addClass("hide-right-btn"), r.doFixedScroll) {
              if (!r.scrollingEnabled) return;
              r.parent.find("table,.scroll-box").not("table table").find("tr, > div").each(function() {
                  e(this).find("th,td").removeClass("contents-in-view").addClass("hide-contents").slice(r.scrolledIndex, r.scrolledIndex + r.fixedItemsToScreen).removeClass("hide-contents").addClass("contents-in-view")
              })
          } else r.parent.find(r.param.childItem).each(function() {
              var t = e(this).position().left + e(this).width() - r.currElemLeft;
              t > r.wrapperWidth ? e(this).addClass("ellipsis") : e(this).removeClass("ellipsis")
          })
      }
  }, r.prototype.scrollIt = function() {
      var t = this;
      t.parent.on("click", ".view-btn-left", function() {
          t.changePos("LEFT")
      }).on("click", ".view-btn-right", function() {
          t.changePos("RIGHT")
      }).on("mouseleave touchend", function() {
          e(this).trigger("mouseup"), t.slideWrapper.css("transform", "translate3d(" + -1 * t.currElemLeft + "px, 0px, 0px)")
      })
  }, r.prototype.swipePlugin = function() {
      var e = this;
      e.hasTouchSwipe && e.doFixedScroll && e.parent.swipe({
          swipe: function(t, r) {
              e.changePos("SWIPE" + r)
          },
          swipeStatus: function(t, r, s, n, i) {
              var a = e.currElemLeft,
                  l = 130 > n ? n : 130;
              "move" === r && e.scrollingEnabled && ("LEFT" === s.toUpperCase() ? e.slideWrapper.css("transform", "translate3d(" + -1 * (a + l) + "px, 0px, 0px)") : "RIGHT" === s.toUpperCase() && e.slideWrapper.css("transform", "translate3d(" + -1 * (a - l) + "px, 0px, 0px)")), "end" !== r && "touchcancel" !== t.type && "mouseup" !== t.type || !e.scrollingEnabled || e.slideWrapper.css("transform", "translate3d(" + -1 * e.currElemLeft + "px, 0px, 0px)")
          },
          allowPageScroll: "vertical"
      })
  }, r.prototype.resizedScreen = function() {
      var t = this;
      return function() {
          var r;
          e(window).on("resize load scrollInView", function() {
              clearTimeout(r), t.slideContainerWidth = t.slideWrapper.width() + t.param.btnSpace, r = setTimeout(function() {
                  t.wrapperWidth = t.parent.find(".in-view-wrapper").width();
                  var r = t.slideContainerUseWidth > t.slideContainerWidth ? t.slideContainerUseWidth : t.slideContainerWidth;
                  r >= t.wrapperWidth && t.param.startWidth >= e(window).width() ? (t.scrollingEnabled = !0, t.getFixedItemsToScreen(), t.btnsAdded || (t.btnsAdded = !0, t.parent.addClass(t.param.buttonsAddedClass).append('<i class="in-view-btn view-btn-left ' + t.param.leftBtnClass + '"/><i class="in-view-btn view-btn-right ' + t.param.rightBtnClass + '"/>')), t.parent.addClass("hide-left-btn"), t.changePos("")) : (t.scrollingEnabled = !1, t.scrolledIndex = 0, t.currElemLeft = 0, t.btnsAdded && (t.btnsAdded = !1, t.parent.removeClass(t.param.buttonsAddedClass + " hide-right-btn hide-left-btn").find(".in-view-btn").remove()), t.slideWrapper.css({
                      transform: "translate3d(0px, 0px, 0px)",
                      width: ""
                  }), t.doFixedScroll ? (t.slideWrapper.css({
                      width: "",
                      "table-layout": ""
                  }), t.parent.find(t.param.childItem).css("width", ""), t.slideWrapper.find("th,td").removeClass("hide-contents")) : t.parent.find(t.param.childItem).removeClass("ellipsis"))
              }, t.param.resizeDelay, t.parentElem, t.param)
          })
      }(t.parentElem, t.param)
  }, e.fn.scrollInView = function() {
      "undefined" == typeof e.fn.swipe ? console.log("please add jquery.touchSwipe.js touch swiping will not work :-/") : t = !0;
      for (var s, n = this, i = arguments[0], a = Array.prototype.slice.call(arguments, 1), l = 0, d = n.length; d > l; l++)
          if ("object" == typeof i || "undefined" == typeof i ? n[l].scrollInView = new r(n[l], i) : s = n[l].scrollInView[i].apply(n[l].scrollInView, a), "undefined" != typeof s) return s;
      return n
  }
}(jQuery);
