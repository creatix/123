
var activesecond='';

function showsecond(pageid) {
	if (document.getElementById('second'+pageid)) {
		if (document.getElementById('second'+pageid).style.display == 'none') {
			document.getElementById('second'+pageid).style.display = 'block';
			document.getElementById('lia'+pageid).className = 'f1selected';
			if (activesecond!='') {
				document.getElementById('second'+activesecond).style.display = 'none';
				document.getElementById('lia'+activesecond).className = 'f1';
			}
			activesecond = pageid;
		} else {
			document.getElementById('second'+pageid).style.display = 'none';
			document.getElementById('lia'+pageid).className = 'f1';
			activesecond = '';
		}
	}
}

var activethird='';

function showthird(pageid) {
	if (document.getElementById('third'+pageid)) {
		if (document.getElementById('third'+pageid).style.display == 'none') {
			document.getElementById('third'+pageid).style.display = 'block';
			document.getElementById('lia'+pageid).className = document.getElementById('lia'+pageid).className + 'selected';
			if (activethird!='' && activethird!=pageid) {
				document.getElementById('third'+activethird).style.display = 'none';
				document.getElementById('lia'+activethird).className = document.getElementById('lia'+activethird).className.replace('selected','');
			}
			activethird = pageid;
		} else {
			document.getElementById('third'+pageid).style.display = 'none';
			document.getElementById('lia'+pageid).className = document.getElementById('lia'+pageid).className.replace('selected','');
		}
	}
}