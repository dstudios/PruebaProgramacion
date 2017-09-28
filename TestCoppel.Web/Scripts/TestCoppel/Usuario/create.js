$(function () {
	TestCoppel.Usuario.create = {
		init: _init
	};

	function _init() {
		_events();
	}

	function _events() {
		var picker = new Pikaday({
			field: $('#FechaNacimiento')[0],
			format: 'MM/DD/YYYY',
			firstDay: 1,
			minDate: new Date(1910, 0, 1),
			maxDate: new Date(2017, 12, 31),
			yearRange: [1910, 2017],
			showTime: false
		});
	}
});