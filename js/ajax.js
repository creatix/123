
var active_project='';

function selectmainnav(pageid) {
	document.getElementById('mainli'+pageid).className = 'C_nav_sel';
	if (pageid == '25') {
		document.getElementById('leftnavcorn').className = 'nav_LA';
	}
}

function load_project(p_id) {
	if (active_project != '') {
		$('ph3'+active_project).className = '';
	}
	$('ph3'+p_id).className = 'box_h';
	active_project = p_id;
	load_html('projectcontainer', 'projectdetails.aspx?id='+p_id);
}

function load_html(cont, url) {
	//$(cont).fade(1,0);
	$(cont).empty().addClass('ajax-loading');
	var req = new Request.HTML({
					method: 'post',
					url: url,
					onRequest: function() {  },
					//update: $('login_win'),
					onComplete: function(response) {
						$(cont).setOpacity(0);
						$(cont).removeClass('ajax-loading');
						$(cont).empty();
						$(cont).adopt(response);
						//myVerticalSlide = new Fx.Slide('cat_strip_container');
						$(cont).fade(0,1);
						initSlider(10);
					}
				}).send();
}

function loadimage(img, img2, desc) {
	//$('mainimage').src = 'components/img.aspx?img=images\\'+img+'&width=601&height=450';
	if (img2 == '') {
		$('mainimagecontainerdiv').innerHTML = '<img src="components/img.aspx?img=images\\'+img+'&width=601&height=450" id="mainimage" width="601" height="450" border="0" title="'+desc+'" />';
	} else {
		$('mainimagecontainerdiv').innerHTML = '<img src="components/img.aspx?img=images\\'+img+'&width=300&height=450" id="mainimage" width="300" height="450" border="0" title="'+desc+'" />';
		$('mainimagecontainerdiv').innerHTML += '<img src="components/img.aspx?img=images\\'+img2+'&width=300&height=450" id="mainimage" width="300" height="450" border="0" title="'+desc+'" />';
	}
	$('picdesc').innerHTML = desc;
}


function initSlider(itemsCount) {
	
	if ($('myList') == null) {
		return;
	}
	
	var totIncrement		= 0;
	var increment			= 94;
	var maxRightIncrement	= increment*(-itemsCount);
	var fx = new Fx.Tween($('myList'), {duration: 600, transition: Fx.Transitions.Quad.easeInOut});
	   
	$('previous').addEvents({
    	'click' : function(event){
			if(totIncrement<0){
				totIncrement = totIncrement+increment;
				//fx.stop()
				//fx.start(totIncrement);
				fx.start('margin-top', totIncrement);
			}
		}			  	  
    }); 
	
	$('previous1').addEvents({
    	'click' : function(event){
			if(totIncrement<0){
				totIncrement = totIncrement+increment;
				//fx.stop()
				//fx.start(totIncrement);
				fx.start('margin-top', totIncrement);
			}
		}			  	  
    }); 
	 
	$('next').addEvents({
    	'click' : function(event){
			if(totIncrement>maxRightIncrement){
				totIncrement = totIncrement-increment;
		    	//fx.stop()
				//fx.start(totIncrement);
				fx.start('margin-top', totIncrement);
			}
		}		  		  
    })
	
	$('next1').addEvents({
    	'click' : function(event){
			if(totIncrement>maxRightIncrement){
				totIncrement = totIncrement-increment;
		    	//fx.stop()
				//fx.start(totIncrement);
				fx.start('margin-top', totIncrement);
			}
		}		  		  
    })
	
}

