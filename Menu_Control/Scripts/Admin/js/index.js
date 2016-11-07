
(function(){

  var $aside = $('.aside');

  /*左侧展开收起*/
  $('ul li .nav-title', $aside).on('click', function() {
    var that = $(this),
      $thisLi = that.closest('li');
    $('dl', $thisLi).slideToggle();
    $thisLi.siblings('li').find('dl').slideUp();
    $thisLi.toggleClass('active').siblings().removeClass('active').siblings().find('a').removeClass('active');
  });

  $('ul li dl dd a', $aside).on('click', function() {
    $(this).addClass('active').closest('dd').siblings().find('a').removeClass('active');
  });



})();





