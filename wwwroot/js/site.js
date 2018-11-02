(function () {
	const mainEl = document.getElementsByTagName('main')[0];
	const newEl = document.createElement('div');
	newEl.style.backgroundColor = 'green';
	newEl.style.color = 'white';
	newEl.style.padding = '10px';
	newEl.style.margin = '10px';
	newEl.style.textAlign = 'center';
	newEl.textContent = 'Element inserted from script file';
	mainEl.insertBefore(newEl, mainEl.firstChild);
}());