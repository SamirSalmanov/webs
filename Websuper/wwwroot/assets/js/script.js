
 $(".all-slider").slick({
      arrows:false,
      autoplay: true,
      autoplaySpeed: 3000
  
      
   })
   function openNav() {
      document.getElementById("mySidenav").style.width = "300px";
    }
    
    function closeNav() {
      document.getElementById("mySidenav").style.width = "0";
    } 
    $(".swiper-wrapper").slick({
      arrows:true,
        autoplay: true,
        autoplaySpeed: 3000,
        vertical: true,
        verticalSwiping: true,
        slidesToShow: 2
     })
     $(".service-slide").slick({
      autoplay: true,
      arrows:false,
      autoplaySpeed: 3000,
   
     })