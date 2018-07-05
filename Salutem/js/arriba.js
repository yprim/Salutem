$(document).ready(function(){

	$('.ir-arriba').click(function(){
		$('body, html').animate({
			scrollTop: '0px'
		},300 );
	});

	// Oculta el boton de arriba
	$(window).scroll(function(){
		// Si se mueve el scroll hacia arriba entonces se oculta el boton y dura 300 ms y de lo contrario se muestra con los mismos 300 ms
		if ($(this).scrollTop() > 0){
			$('.ir-arriba').slideDown(300);
		} else {
			$('.ir-arriba').slideUp(300);
		};
	});
	
});