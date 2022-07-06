import Sortable from 'sortablejs';

var gridDemo = document.getElementById('gridDemo')

new Sortable(gridDemo, {
	animation: 150,
	ghostClass: 'blue-background-class'
});

