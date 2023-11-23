function findGender(relation) {

	let gender = "";

	switch (relation) {
		case 'Husband':
		case 'Father':
		case 'Brother':
		case 'Son':
			gender = "Male";
			break;
		case 'Spouse':
		case 'Mother':
		case 'Sister':
		case 'Daughter':
			gender = "Female";
			break;
		default:
			gender = "Unknown";
			break;
	}

	return gender;
}
function getTotalYearFromDateOfBirth(dob) {
	var start = new Date(dob);
	var end = new Date();
	var diff = new Date(end - start) / (1000 * 60 * 60 * 24 * 365.25);
	var age = Math.round(diff);
	return age;
}

function formatDate(date = new Date()) {
	const year = date.toLocaleString('default', { year: 'numeric' });
	const month = date.toLocaleString('default', {
		month: '2-digit',
	});
	const day = date.toLocaleString('default', { day: '2-digit' });

	return [year, month, day].join('-');
}
function getAmountAfterCheckingNaNAndUndefind(data) {
	var amt = parseInt(data);
	if (isNaN(amt) || amt == undefined)
		amt = 0;
	return amt;
}