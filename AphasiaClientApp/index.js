import Sortable from 'sortablejs';

import $, { error } from "jquery";

var gridDemo = document.getElementById('gridDemo')

new Sortable(gridDemo, {
	animation: 150,
	ghostClass: 'blue-background-class'
});
