/*! umbraco
 * https://github.com/umbraco/umbraco-cms/
 * Copyright (c) 2016 Umbraco HQ;
 * Licensed MIT
 */

(function() { 

angular.module('umbraco.filters', []);
angular.module("umbraco.filters").filter('timespan', function() {
    return function(input) {
      var sec_num = parseInt(input, 10);
      var hours   = Math.floor(sec_num / 3600);
      var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
      var seconds = sec_num - (hours * 3600) - (minutes * 60);

      if (hours   < 10) {hours   = "0"+hours;}
      if (minutes < 10) {minutes = "0"+minutes;}
      if (seconds < 10) {seconds = "0"+seconds;}
      var time    = hours+':'+minutes+':'+seconds;
      return time;
    };
  });
	

})();