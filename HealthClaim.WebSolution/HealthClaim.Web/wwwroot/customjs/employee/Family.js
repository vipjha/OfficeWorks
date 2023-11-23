var gender = '';
var empId = 3;
$(document).ready(function () {
	BindEmployeeAboutMe();
	BindEmployeeMembers();

	BindEmployeeRelation();
	$('#ddlEmployeerelation').change(function () {

		var ddlText = $("#ddlEmployeerelation option:selected").text();
		var chkSpouse = $("#chkSpouse").prop('checked');
		//alert(chkSpouse);
		gender = findGender(ddlText);
		debugger;
		if (ddlText == "Spouse") {
			$('#IsDeclarationVisble').css('display', 'block');
			$('#isSpouseVisbile').css('display', 'block');
			$('#isChildVisble').css('display', 'none');
		}

		else if (ddlText == "Son" || ddlText == "Daughter") {
			$('#IsDeclarationVisble').css('display', 'block');
			$('#isChildVisble').css('display', 'block');
			$('#isSpouseVisbile').css('display', 'none');

		}
		else {
			$('#IsDeclarationVisble').css('display', 'none');
		}

	});

	$("#btnAddFamilyMember").click(function () {
		debugger;
		var isformIsvalid = true;
		var financialYear = $("#ddlFinancialYear option:selected").text();
		var memberName = $('#txtMemberName').val();
		var panNo = $('#txtPanNo').val();
		var annualIncome = $('#txtAnnualIncome').val();
		var employeerelationId = $('#ddlEmployeerelation').val();
		var date = $('#ddlDate').val();
		var month = $('#ddlMonth').val();
		var year = $('#ddlYear').val();
		var totalage = $('#txtTotalAge').val();

		var dob = month + "/" + date + "/" + year;
		var gender = $("#ddlEmployeerelation option:selected").text();
		gender = findGender(gender);

		if (memberName == '') {
			$('#txtMemberName').css('border-color', 'red');
			$('#txtMemberName').focus();
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		if (employeerelationId == '0') {
			$('#ddlEmployeerelation').css('outline', '1px solid red');
			//$('#ddlEmployeerelation').css('color', 'red');
			$('#ddlEmployeerelation').focus();
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		if (dob == 'DD/MM/YYYY') {

			$('#ddlDate').css('outline', '1px solid red');
			//$('#ddlDate').css('color', 'red');
			$('#ddlMonth').css('outline', '1px solid red');
			//$('#ddlMonth').css('color', 'red');
			$('#ddlYear').css('outline', '1px solid red')
			//$('#ddlYear').css('color', 'red');
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		if (date == 'DD') {
			$('#ddlDate').css('outline', '1px solid red');
			//$('#ddlDate').css('color', 'red');
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		if (month == 'MM') {
			$('#ddlMonth').css('outline', '1px solid red');
			//$('#ddlMonth').css('color', 'red');
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		if (year == 'YYYY') {
			$('#ddlYear').css('outline', '1px solid red')
			//$('#ddlYear').css('color', 'red');
			isformIsvalid = false;
		}
		else {
			isformIsvalid = true;
		}
		debugger;

		var itrFile = new FormData();
		var fileITR = $('#itrFile')[0].files[0];
		itrFile.append('file', fileITR);
		if (employeerelationId == '1' || employeerelationId == '2') {
			if (fileITR == null || fileITR == undefined) {
				$('.itr-label').css('border-color', 'red');
				isformIsvalid = false;
			}
			else {
				isformIsvalid = true;
			}
			if ($('#txtAnnualIncome').val() == '') {
				$('#txtAnnualIncome').css('border-color', 'red');
				$('#txtAnnualIncome').focus();
				isformIsvalid = false;
			}
			else {
				isformIsvalid = true;
			}
			if ($('#txtPanNo').val() == '') {
				$('#txtPanNo').css('border-color', 'red');
				$('#txtPanNo').focus();
				isformIsvalid = false;
			}
			else {
				isformIsvalid = true;
			}

		}


		//var panFile = new FormData();
		//var filePAN = $('#panFile')[0].files[0];
		//panFile.append('file', filePAN);
		if (!isformIsvalid) {
			return false;
		}

		var data =
		{
			"empId": empId,
			"name": memberName,
			"relationId": parseInt(employeerelationId),
			"gender": gender,
			"ITRFile": fileITR,
			"FinancialYear": financialYear,
			"AnnualIncome": parseInt(annualIncome),
			//"PANFile": filePAN,
			"PANNo": panNo,
			"dateOfBirth": dob,
			"emailId": "na@na.com",
			"mobileNo": "123456789",
			"bloodGroup": "O+",
			"isActive": true
		};
		var formdata = { employeefamilyModel: data };

		//FormData Object
		const formDataNew = new FormData();
		formDataNew.append('name', data.name)
		formDataNew.append('gender', data.gender)
		formDataNew.append('empId', data.empId)
		formDataNew.append('relationId', data.relationId)
		formDataNew.append('emailId', data.emailId)
		formDataNew.append('mobileNo', data.mobileNo)
		formDataNew.append('bloodGroup', data.bloodGroup)
		formDataNew.append('dateOfBirth', data.dateOfBirth)
		formDataNew.append('isActive', data.isActive)
		formDataNew.append('ITRFile', data.ITRFile)
		formDataNew.append('FinancialYear', data.FinancialYear)
		formDataNew.append('AnnualIncome', data.AnnualIncome)
		//formDataNew.append('PANFile', data.PANFile)
		formDataNew.append('PANNo', data.PANNo)

		//console.log(data)
		$.ajax({
			type: "POST",
			url: apiBaseUrl + "/api/Employeefamily/CreateEmpRelation",
			data: formDataNew,
			//contentType: 'multipart/form-data',
			processData: false,
			contentType: false,
			//dataType: "json",
			beforeSend: function () {
				$('.page-loader').show();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
			},
			success: function (response) {

				if (response.statusCode == 201) {
					swal({
						title: 'Awesome !',
						text: response.message,
						type: 'success'
					});
				}
				else {
					swal({
						title: 'Invalid !',
						text: response.message,
						type: 'error'
					});
				}
				BindEmployeeMembers();
				$('#myModal').modal('hide');

			},
			complete: function () {

				$('.page-loader').hide();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
			},
			error: function (jqXHR, status) {
				// error handler
				//console.log(jqXHR);
				//console.log(jqXHR.responseJSON);
				//console.log();
				swal({
					title: 'Invalid !',
					text: jqXHR.responseJSON.message,
					type: 'error'
				});
				$('.page-loader').hide();
				$("#btnAddFamilyMember").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
			}
		});
	});

	$("#ddlYear").change(function () {
		var date = $('#ddlDate').val();
		var month = $('#ddlMonth').val();
		var year = $('#ddlYear').val();

		var dob = month + "/" + date + "/" + year;
		var totalAge = getTotalYearFromDateOfBirth(dob);
		$('#txtTotalAge').val(totalAge);
	});
});

function BindEmployeeRelation() {
	var ddlEmployeerelation = $('#ddlEmployeerelation');

	$.ajax({
		type: "GET",
		url: apiBaseUrl + "/api/Employeefamily/GetRelation/0",
		data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			//console.log(response)
			//console.log(response.statusCode)

			$.each(response.data, function () {
				ddlEmployeerelation.append($("<option></option>").val(this['id']).html(this['name']));
			});
		},
		failure: function (response) {
			alert(response.d);
		}
	});
}
function BindEmployeeMembers() {
	$('#tbodyContent').empty();
	var ddlEmployeerelation = $('#tbodyContent');

	$.ajax({
		type: "GET",
		url: apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString(),
		data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		beforeSeend: function () {
			$('.page-loader').show();

		},
		success: function (response) {
			//console.log(response)
			//console.log(response.statusCode)
			//ddlEmployeerelation.append('');
			ddlEmployeerelation.empty();
			$.each(response.data, function () {
				var itrView = '<td></td>';
				if (this['relation'] == 'Father' || this['relation'] == 'Mother') {
					itrView = '<td class="text-center"><a href=' + this['itrPath'] + ' class="btn btn-sm btn-size"><i class="fa fa-eye" aria-hidden="true"></i> View File</a></td>';
				}
				if (this['relation'] != 'Self') {


					var htmlContent = `'<tr>
					<td> `+ this['memberName'] + `</td>
                        <td>`+ this['relation'] + `</td>
                        <td class="text-center">`+ this['dob'] + `</td>
                        <td class="text-center">`+ this['age'] + `</td>
                        <td class="text-center">`+ this['gender'] + `</td>
						`+ itrView + `
						
                    </tr>'`;

					ddlEmployeerelation.append(htmlContent);
				}
			});
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}

// Bind Employee About Me
function BindEmployeeAboutMe() {
	debugger;
	$.ajax({
		type: "GET",
		url: apiBaseUrl + "/api/Employee/GetEmployeeAboutMe/" + empId.toString(),
		data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		beforeSeend: function () {
			$('.page-loader').show();

		},
		success: function (response) {
			//console.log(response)
			//console.log(response.statusCode)
			//ddlEmployeerelation.append('');
			console.log(response);
			if (response.statusCode == 200) {
				var totalAge = getTotalYearFromDateOfBirth(response.data.dateOfBirth);

				$('#employeeID').html(response.data.employeeId);
				$('#dateofjoining').html(response.data.dateOfJoining);
				$('#dob').html(response.data.dateOfBirth);
				$('#age').html(totalAge);
				$('#empname').html(response.data.employeeName);
				$('#emailid').html(response.data.emailId);
				$('#mobile').html(response.data.mobile);
				$('#gender').html(response.data.gender);
			}
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}


