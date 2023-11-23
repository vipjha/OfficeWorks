//Global Declartion
/// Upload Task
var empId = 3;
var isParent = false;
/// View Document Code
var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [], ReviseEstimateAmount: [] }
var topUpDataDetails = [];
function TrigerModalViewFile(type, type2) {
	$("#viewModal").modal('show');
	$("#modelTitle").html(type)
	$("#tbodyViewDocuments").empty();
	count = 1;
	// debugger;
	for (let e of documentDetails[type2]) {
		let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e.pathUrl}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
		$("#tbodyViewDocuments").append(row)
		count++;
	}
	//$('#myModalTitle').html(type);
	//$('#spnComment').html(type);
	//loadUploadedFile(type2);
}

function TrigerModalViewFileTopUp(type, type2, index) {
	$("#viewModal").modal('show');
	$("#modelTitle").html(type)
	$("#tbodyViewDocuments").empty();
	count = 1;
	//debugger;
	for (let e of topUpDataDetails[index].ReviseEstimateFiles) {
		let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
		$("#tbodyViewDocuments").append(row)
		count++;
	}
	//$('#myModalTitle').html(type);
	//$('#spnComment').html(type);
	//loadUploadedFile(type2);
}
// Upload Multiple JavaScript start
var uploadType = '';
var uploadKey = '';
var fileData = [];
var uploadDetails = { AdmissionAdvice: [], Diagnosis: [], EstimateAmount: [], ReviseEstimateAmount: [], ITRIncomeProof: [] };
var imgUpload = document.getElementById('upload-img')
	, imgPreview = document.getElementById('img-preview')
	, imgUploadForm = document.getElementById('form-upload')
	, totalFiles
	, previewTitle
	, previewTitleText
	, img;

imgUpload.addEventListener('change', previewImgs, true);
var trBodyUploadDoc = document.getElementById('trBodyUploadDoc');
function loadUploadedFile(key) {
	var row = '';
	let count = 1;
	if (uploadDetails[key].length == 0) {
		trBodyUploadDoc.innerHTML = '';
		return;
	}
	for (let e of uploadDetails[key]) {
		row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadType}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_file(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
		count++;

	}
	trBodyUploadDoc.innerHTML = row;
}
function previewImgs(event) {

	if (imgUpload.files.length == 0) {
		return;
	}
	const original = imgUpload.files[0];
	const clone = new File([original], original.name, {
		type: original.type,
		lastModified: original.lastModified,
	});
	let comment = textareaComment.value;
	debugger;
	uploadDetails[uploadKey].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
	debugger;
	$("#span" + uploadKey).html(uploadDetails[uploadKey].length);
	imgUpload.value = null;
	loadUploadedFile(uploadKey);
}
function delete_file(index) {
	uploadDetails[uploadKey].splice(index, 1);
	$("#span" + uploadKey).html(uploadDetails[uploadKey].length);
	loadUploadedFile(uploadKey);
}
function TrigerModalUploadFile(type, type2) {
	uploadType = type;
	uploadKey = type2;
	$("#myModal").modal('show');
	$('#myModalTitle').html(type);
	$('#spnComment').html(type);
	loadUploadedFile(type2);
}
// Upload Multiple JavaScript End
// Parent

var divParentClaimLimt = document.getElementById('divParentClaimLimt');
var ITRIncomeProof = document.getElementById('ITRIncomeProof');
var textareaComment = document.getElementById('textareaComment');
/// Upload Task end
var spanTotalLimit = document.getElementById('spanTotalLimit');

var spanTotalLimit = document.getElementById('spanTotalLimit');

var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');
var selectMember = document.getElementById('selectMember');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var inputEstimateAmount = document.getElementById('inputEstimateAmount');
var inputAdvanceRequired = document.getElementById('inputAdvanceRequired');

var divHospitalName = document.getElementById('divHospitalName');
var inputDiagnosis = document.getElementById('inputDiagnosis');
var inputBranchName = document.getElementById('inputBranchName');
var inputGstNo = document.getElementById('inputGstNo');

var selectTreatmentType = document.getElementById('selectTreatmentType');
var radioEmpanelledHospitalsYes = document.getElementById('radioEmpanelledHospitalsYes');

var radioPaytoSelf = document.getElementById('radioPaytoSelf');
var radioPaytoHospital = document.getElementById('radioPaytoHospital');

var inputBankName = document.getElementById('inputBankName');
var inputIFSC = document.getElementById('inputIFSC');
var inputBeneficiaryName = document.getElementById('inputBeneficiaryName');
var inputAccountNo = document.getElementById('inputAccountNo');
var inputConfirmAccountNo = document.getElementById('inputConfirmAccountNo');
var btnSubmitWithoutBankDetails = document.getElementById('btnSubmitWithoutBankDetails');
var btnSubmitAfterBankDetails = document.getElementById('btnSubmitAfterBankDetails');
var divhospitaldetails = document.getElementById('divhospitaldetails');



function bindTableAdvanceClaim() {
	var tblAdvanceClaim = $('#tbodyAdvanceApprovedList');
	var url = apiBaseUrl + "/api/Claim/GetAdvanceClaimApproved?empId=" + empId.toString();
	url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
	$.ajax({
		type: "GET",
		url: url,
		//data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		beforeSeend: function () {
			$('.page-loader').show();

		},
		success: function (response) {
			/*console.log(response)
			console.log(response.statusCode)*/
			tblAdvanceClaim.append('');
			var count = 1;
			$.each(response.data, function () {

				debugger;
				var rowAdvanceApproved = ` <tr>
                            <td>${count}</td>
                            <td>
                                ${this.employeeName}                                
                            </td>

                            <td>
                                ${this.patientName}
                            
                            </td>
                            <td>
                                    ${this.relation}
                                    
                            </td>
                            <td>
                                ${this.advanceAmount}
                               
                            </td>
                            <td>
                                 ${this.requestDate}
                                 
                            </td>
                            <td>
                                ${this.approvedAmount}
                                
                            <td>
                                ${this.approvedDate}
                                
                            </td>
                            <td>
                                <input type="button" onclick="topup_click(${this.empId},'${this.patientName}','${this.relation}',${this.advanceId},${this.patientid})" class="btn btn-primary" value="Top Up">
                            </td>
                        </tr>`;

				tblAdvanceClaim.append(rowAdvanceApproved);
				count++;
			});
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}
var itrParent = document.getElementById('itrParent');
function topup_click(emp_id, patient_name, relation, advanceId, pId) {
	AdvanceId = advanceId;
	//cur_relation = relation;

	$("#chkNewAdvanceRequest").prop('checked', false);
	$("#divNewAdvanceRequest").css('display', 'none');
	$("#divTopUp").css('display', 'block');
	$("#divSubmit").css('display', 'block');
	$("#divEmPanelledTopUp").css('display', 'block');
	$("#radioPaytoSelfTopUp").prop('checked', true);
	divhospitaldetails.style.display = 'none';


	getAndFillAdvanceApprovedAndTopDetailDetailsByAdvanceID(advanceId);
	ShowHideParentLimit(relation, pId, true);
}
var inputTreatmentType = document.getElementById('inputTreatmentType');
var inputPayTo = document.getElementById('inputPayTo');
function getAndFillAdvanceApprovedAndTopDetailDetailsByAdvanceID(advanceID) {
	debugger;
	var url = apiBaseUrl + "/api/Claim/GetClaimDetails/" + advanceID.toString();
	url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
	$.ajax({
		type: "GET",
		url: url,
		//data: '{}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		beforeSeend: function () {
			$('.page-loader').show();

		},
		success: function (response) {
			var JsonData = response.data;
			documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
			$("#spanAdmissionAdviceUploadView").html(documentDetails.AdmissionAdviceUpload.length);
			//documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
			//$("#spanDiagnosisView").html(documentDetails.Diagnosis.length);
			documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
			$("#spanEstimateAmountView").html(documentDetails.EstimateAmount.length);
			tdPatientName.innerHTML = JsonData.advanceBasicDetails.patientName;
			tdPatientRelation.innerHTML = JsonData.advanceBasicDetails.relation;
			tdDateOfBirth.innerHTML = JsonData.advanceBasicDetails.dateOfBirth;
			tdGender.innerHTML = JsonData.advanceBasicDetails.gender;
			$("#spanHospitalName").html(JsonData.advanceBasicDetails.hospitalName);
			$("#spanDoctorName").html(JsonData.advanceBasicDetails.doctorName);
			$("#spanActualDateOfAdmission").html(formatDate(new Date(Date.parse(JsonData.advanceBasicDetails.likelyDate))));
			$("#spanEstimatedAmount").html(JsonData.advanceBasicDetails.estimatedAmount);
			$("#spanApprovedAmount").html(JsonData.advanceBasicDetails.claimApprovedAmount);
			$("#spanTreatmentType").html(JsonData.advanceBasicDetails.ctreatmentType);
			$("#spanDiagnosis").html(JsonData.advanceBasicDetails.digonosis);
			$("#spanPayTo").html(JsonData.advanceBasicDetails.payTo);
			if (JsonData.advanceBasicDetails.payTo.toUpperCase() == "SELF") {
				$("#divbankdetails").css('display', 'block');
				$("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
				$("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
				$("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
				$("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
				$("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
				$("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
				// Two Field Required
				$("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
				$("#spanTransactionDate").html(JsonData.hospitalAccoundetail.transactionDate);

			}
			else {
				$("#divbankdetails").css('display', 'none');


			}
			addTopUpDetail(JsonData.topUpDetails);
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}
function addTopUpDetail(topUpDetails) {
	topUpDataDetails.length = 0;
	debugger;
	if (topUpDetails.length != 0) {
		for (let e of topUpDetails) {
			var path = []
			for (let p of e.reviseEstimateFiles) {
				path.push(p.filePath);
			}
			var topUpObject = { ReviseEstimateAmount: e.reviseEstimentedAmount, RequiredTopUpAmount: e.topRequiredAmount, ApprovedTopUpAmount: e.approvedAmount, ReviseEstimateFiles: path }
			topUpDataDetails.push(topUpObject);
		}

	}

	let count = 0;
	$("#topUpDetails").empty();
	for (let e of topUpDataDetails) {
		var newDiv = `<div  class="col-lg-12 grid-margin stretch-card">
    <div class="card">
        <div class="card-body">
            <h4 class="card-title mt-1 mb-2"><span>${count + 1}.</span>&nbsp; Top Up Details</h4>
            <div class="row">
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Revise Estimate Amount</label>
                        <div class="col-sm-3 estimatemobile">
                            <input id="inputReviseEstimateAmount${count + 1}" type="tel" value="${e.ReviseEstimateAmount}" class="form-control amt" placeholder="₹ 1,80,000.00" readonly>
                        </div>
                        <div class="col-sm-4 estimatemobileupload">
                            <div class="form-group">
                                <button type="button" onclick="TrigerModalViewFileTopUp('Revise Estimate Amount','ReviseEstimateAmount',${count})" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File <span id="spanReviseEstimateAmount${count + 1}" class="file-status">${topUpDataDetails[count].ReviseEstimateFiles.length}</span>  </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Requested Top Up Amount</label>
                        <div class="col-sm-7">
                            <input id="inputTopUpAmountRequired${count}" value="${e.RequiredTopUpAmount}" type="text" class="form-control amo" placeholder="₹ 80,000.00" readonly>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Approved Top Up Amount</label>
                        <div class="col-sm-7">
                            <input id="inputTopUpApprovedAmount${count}" value="${e.ApprovedTopUpAmount}"  type="text" class="form-control amo" placeholder="₹ 80,000.00" readonly>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>`;
		$("#topUpDetails").append(newDiv);
		count++;
	}
}
//Events
function radioEmpanelledHospitals_Click(e, type) {
	if (type == "Yes") {
		$("#divEmpanelledHospitals").css('display', 'block');
		$("#divHospitalName").css('display', 'none');
		$("#divHospitalRegdNo").css('display', 'none');
		$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'none');

	}
	else {
		$("#divEmpanelledHospitals").css('display', 'none');
		$("#divHospitalName").css('display', 'block');
		$("#divHospitalRegdNo").css('display', 'block');
		$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'block');
	}
}

$(document).ready(function () {
	bindTableAdvanceClaim();
});
function rbt_self_onchange(e) {
	if (e.value == 'self') {
		divhospitaldetails.style.display = 'none';
	}
	else {
		divhospitaldetails.style.display = 'block';

	}
	if (isAdvance) {
		if (radioEmpanelledHospitalsYes.checked) {
			$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'none');
		}
		else {
			$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'block');
		}

	}
	else {

	}
}
var selectHospital = document.getElementById('selectHospital');
function checkValidationBeforeSubmitPostRequest() {
	if (!inputDateOfAdmission.checkValidity()) {
		swal({
			title: 'Invalid !',
			text: 'Please Enter Likely date of Admission',
			type: 'error'
		});
		return false;
	}
}
function inputIFSC_OnFocusOut() {
	var url = apiBaseUrl + "/api​/Common​/IFSCCodeChecker​/" + inputIFSC.value;
	url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
	// Start Loader Here

	if (inputIFSC.value != '') {
		$('.page-loader').show();
		getApiCall(url = url, success, failour);
		function success(response) {
			debugger;
			var jsonData = response.data;
			if (response.statusCode == 200) {
				inputBankName.value = jsonData.bank;
				inputBranchName.value = jsonData.branch;
			}
			$('.page-loader').hide();


			//// Close Loader Here;
		}
		function failour(response) {
			//// Close Loader Here;
			$('.page-loader').hide();
		}
	}

}
$("#btSubmitRequest").click(function () {
	//FormData Object
});

function selectMember_OnChange(e) {

	ShowHideParentLimit(e.options[e.selectedIndex].text, e.options[e.selectedIndex].value, false);
}
//Functions
function setAdvanceDefaultValue() {
	spanTotalLimit.innerHTML = rupee.format(1000000.00);// rupee define in commonformat.js
	spanUsedLimit.innerHTML = rupee.format(250000.00);// rupee define in commonformat.js
	spanBalanceLimit.innerHTML = rupee.format(750000.00);// rupee define in commonformat.js
}

// ApiCallFunctions
function loadFamilyMembers() {
	var url = apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString();
	// Start Loader Here
	getApiCall(url = url, success, failour);
	function success(response) {
		var jsonData = response.data;
		selectMember.options.length = 0;

		for (let e of jsonData) {
			let option = new Option(e['memberName'] + "(" + e['relation'] + ")", e['id']);
			selectMember.add(option, undefined);
		}
		ShowHideParentLimit(selectMember.options[0].text, selectMember.options[0].value, false);

		//// Close Loader Here;
	}
	function failour(response) {
		//// Close Loader Here;
	}
}

function ShowHideParentLimit(relation, familyId, isView = false) {
	if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
		isParent = true;

		getItrDetailsOfParentFromApi(familyId, isView);
	}
	else {
		if (isView) {
			debugger;
			$("#divParentClaimLimitView").css('display', 'none');
			$("#itrParentView").css('display', 'none');

		}
		else {
			divParentClaimLimt.style.display = 'none';
			itrParent.style.display = 'none';
		}
		isParent = false;
	}
}
function getItrDetailsOfParentFromApi(familyId, isView) {
	var _url = apiBaseUrl + "​/api/Common/GetITRDetails/" + familyId;
	_url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
	// Start Loader Here
	getApiCall(_url, success, failour);
	function success(response) {
		var jsonData = response.data;
		debugger;
		if (response.statusCode == 200 && response.message == "ITR Details found.") {
			if (isView) {
				$("#divParentClaimLimitView").css('display', 'block');
				$("#itrParentView").css('display', 'block');
				$("#anchorItrView").attr('href', jsonData.itrFilePath);
				spanTotalLimitView.innerHTML = jsonData.totalLimit;
				spanUsedLimitView.innerHTML = jsonData.usedLimit;
				spanBalanceLimitView.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);
			}
			else {
				divParentClaimLimt.style.display = 'block';
				itrParent.style.display = 'block';
				$("#anchorItr").attr('href', jsonData.itrFilePath);
				spanTotalLimit.innerHTML = jsonData.totalLimit;
				spanUsedLimit.innerHTML = jsonData.usedLimit;
				spanBalanceLimit.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);

			}

		}
		else {
			divParentClaimLimt.style.display = 'block';
			itrParent.style.display = 'none';

			//swal({
			//    title: 'Invalid !',
			//    text: 'Your Parents Valid ITR Detail is not available with us Please visit profile section and upload valid ITR Details',
			//    type: 'error'
			//});
		}
		//// Close Loader Here;
	}
	function failour(response) {
		//// Close Loader Here;
	}
}
function EstimateAmount_focusOut(e) {
	var requiredAmount = parseInt(inputAdvanceRequired.value);
	var estimateAmount = parseInt(e.value);
	if (isParent) {
		if (!isNaN(estimateAmount) && estimateAmount > 0) {
			$("#inputAdvanceRequired").attr('readonly', false);
			if (!isNaN(requiredAmount) && requiredAmount > 0) {
				if (requiredAmount > (.80 * estimateAmount)) {
					inputAdvanceRequired.value = (.80 * estimateAmount).toFixed(0);
				}
			}
		}
		else {
			$("#inputAdvanceRequired").attr('readonly', true);
			inputAdvanceRequired.value = 0;
		}
	}
	else {
		if (!isNaN(estimateAmount) && estimateAmount > 0) {
			$("#inputAdvanceRequired").attr('readonly', false);
			if (!isNaN(requiredAmount) && requiredAmount > 0) {
				if (requiredAmount > estimateAmount) {
					inputAdvanceRequired.value = estimateAmount.toFixed(0);
				}
			}
		}
		else {
			$("#inputAdvanceRequired").attr('readonly', true);
			inputAdvanceRequired.value = 0;
		}

	}


}
function requiredAmount_focusOut(e) {
	var requiredAmount = parseInt(e.value);
	var estimateAmount = parseInt(inputEstimateAmount.value);
	if (isParent) {
		if (!isNaN(requiredAmount) && requiredAmount > 0) {
			if (requiredAmount > (.80 * estimateAmount)) {
				inputAdvanceRequired.value = (.80 * estimateAmount).toFixed(0);
				swal({
					title: 'Invalid !',
					text: 'More than 80% of Estimated Amount is not allowed',
					type: 'error'
				});
			}
		}
	}
	else {
		if (!isNaN(requiredAmount) && requiredAmount > 0) {
			if (requiredAmount > estimateAmount) {
				inputAdvanceRequired.value = estimateAmount;
				swal({
					title: 'Invalid !',
					text: 'More than Estimated Amount is not allowed',
					type: 'error'
				});
			}
		}
	}

}

var isAdvance = false;
function chkNewAdvanceRequest_click(e) {
	$("#divhospitaldetails").css('display', 'none');
	$("#divEmPanelledTopUp").css('display', 'none');
	if (e.checked) {
		isAdvance = true

		$("#divNewAdvanceRequest").css('display', 'block')
		$("#divSubmit").css('display', 'block')
		$("#divTopUp").css('display', 'none');


		loadFamilyMembers();
	}
	else {
		$("#divNewAdvanceRequest").css('display', 'none')
		$("#divSubmit").css('display', 'none')

	}
}
var btnAdvanceRequest = document.getElementById('btnAdvanceRequest');
function checkboxDeclaration_cick(e) {

	if (e.checked) {
		btnAdvanceRequest.disabled = false;
	}
	else {
		btnAdvanceRequest.disabled = true;
	}
}
var inputReviseEstimateAmount = document.getElementById('inputReviseEstimateAmount');
var radioPaytoSelfTopUp = document.getElementById('radioPaytoSelfTopUp');
var radioHospitalEmpanelledYesTopUP = document.getElementById('radioHospitalEmpanelledYesTopUP');
var selectHospitalTopUp = document.getElementById('selectHospitalTopUp');
function btnAdvanceRequestSubmit_Click() {
	if (isAdvance) {

		const formDataNew = new FormData();
		formDataNew.append('EmplId', empId);
		formDataNew.append('PatientId', selectMember.value);
		formDataNew.append('RequestName', 'FirstAdvance');
		//formDataNew.append('AdvanceRequestDate', date.toJSON());

		formDataNew.append('AdvanceAmount', parseInt(inputAdvanceRequired.value));
		formDataNew.append('EstimateAmount', parseInt(inputEstimateAmount.value));
		formDataNew.append('Reason', 'NA');

		if (radioPaytoSelf.checked) {
			formDataNew.append('PayTo', 'Self');
		}
		else {
			formDataNew.append('PayTo', 'Hospital');
			formDataNew.append('BankName', inputBankName.value);
			formDataNew.append('BeneficiaryAccountNo', inputAccountNo.value);
			formDataNew.append('IFSCCode', inputIFSC.value);
			formDataNew.append('BeneficiaryName', inputBeneficiaryName.value);
			formDataNew.append('BranchName', inputBranchName.value);
			formDataNew.append('HospitalGSTNumber', inputGstNo.value);

		}
		//formDataNew.append('approvalDate', '1980/01/01');
		//formDataNew.append('ApprovedAmount', 0);
		//formDataNew.append('ApprovedById', 18)

		//formDataNew.append('DateOfAdmission ', inputDateOfAdmission.value);
		formDataNew.append('DoctorName', inputDoctorName.value);

		for (var e of uploadDetails.AdmissionAdvice) {
			formDataNew.append('AdmissionAdviceFile', e.uploadedFile);
		}
		for (var e of uploadDetails.EstimateAmount) {
			formDataNew.append('EstimateAmountFile', e.uploadedFile);
		}
		//for (var e of uploadDetails.Diagnosis) {
		//    formDataNew.append('DiagnosisFile', e.uploadedFile);
		//}
		formDataNew.append('LikelyDateofAddmison', inputDateOfAdmission.value);
		formDataNew.append('Digonosis', inputDiagnosis.value);
		formDataNew.append('TreatmentType', selectTreatmentType.value);
		if (radioEmpanelledHospitalsYes.checked) {
			formDataNew.append('IsHospitialEmpanpanelled', true);
			formDataNew.append('HospitalId', selectHospital.value);
			formDataNew.append('HospitalName', selectHospital.options[selectHospital.selectedIndex].text);

		}
		else {
			formDataNew.append('IsHospitialEmpanpanelled', false);
			formDataNew.append('HospitalName', inputHospitalName.value);
			formDataNew.append('HospitalRegNo', inputHospitalRegdNo.value);
		}
		//if (!checkValidationBeforeSubmitPostRequest()) {
		//    return;
		//}                                                          
		//var _url = 'https://uat.dfccil.services.cetpainfotech.com/api/Claim/AdvanceRequest​';
		var _url = apiBaseUrl + "​/api/Claim/AdvanceRequest";
		_url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

		$.ajax({
			type: "POST",
			url: _url,
			data: formDataNew,
			processData: false,
			contentType: false,
			beforeSend: function () {
				$('.page-loader').show();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
			},
			success: function (response) {

				if (response.statusCode == 201) {
					swal({
						title: 'Sucess !',
						text: 'Advance request has been successfully submitted!',
						type: 'success'
					});
				}
				else {
					swal({
						title: 'Invalid !',
						text: 'Bad request try agin.',
						type: 'error'
					});
				}

				$('#myModal').modal('hide');

			},
			complete: function () {

				$('.page-loader').hide();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
			},
			error: function (jqXHR, status) {
				$('.page-loader').hide();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
				swal({
					title: 'Invalid !',
					text: jqXHR.responseJSON.message,
					type: 'error'
				});

			}
		});
	}
	else {
		const formDataNew = new FormData();
		formDataNew.append('AdvanceId', AdvanceId);
		formDataNew.append('EmpId', empId);
		formDataNew.append('ReviseEstimentedAmount', parseInt(inputReviseEstimateAmount.value));
		formDataNew.append('TopRequiredAmount', parseInt(inputTopUpAmountRequired.value));

		if (radioPaytoSelfTopUp.checked) {
			formDataNew.append('PayTo', 'self');
		}
		else {
			formDataNew.append('PayTo', 'Hospital');
			formDataNew.append('BankName', inputBankName.value);
			formDataNew.append('AccountNumber', inputBeneficiaryName.value);
			formDataNew.append('IfscCode', inputIFSC.value);
			formDataNew.append('BeneficiaryName', inputBeneficiaryName.value);
			formDataNew.append('BranchName', inputBranchName.value);
			formDataNew.append('HospitalGstNumber', inputGstNo.value);
		}

		for (var e of uploadDetails.ReviseEstimateAmount) {
			formDataNew.append('ReviseEstimateFile.Files', e.uploadedFile);

		}

		formDataNew.append('ReviseEstimateFile.FileComment', 'NA');
		if (radioHospitalEmpanelledYesTopUP.checked) {
			formDataNew.append('IsHospitialEmpanpanelled', true);
			formDataNew.append('HospitalId', selectHospitalTopUp.value);
		}
		else {
			formDataNew.append('IsHospitialEmpanpanelled', false);
			formDataNew.append('HospitalId', '0');
		}


		var _url = apiBaseUrl + "​/api/Claim/AdvanceTopUp";
		_url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

		$.ajax({
			type: "POST",
			url: _url,
			data: formDataNew,
			processData: false,
			contentType: false,
			beforeSend: function () {
				$('.page-loader').show();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
			},
			success: function (response) {

				if (response.statusCode == 201) {
					swal({
						title: 'Success !',
						text: 'Top Up request has been successfully submitted!',
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

				$('#myModal').modal('hide');

			},
			complete: function () {

				$('.page-loader').hide();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
			},
			error: function (jqXHR, status) {
				$('.page-loader').hide();
				$("#btnAdvanceRequest").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
				swal({
					title: 'Invalid !',
					text: jqXHR.responseJSON.message,
					type: 'error'
				});

			}
		});


	}

}
var old_adv_amount = 0;
var sum_of_old_top = 0;
var new_topup_amount = 0;
function ReviseEstimateAmount_click(e) {

	calculate_claim_amount_for_top_up();
	//debugger;
	var requiredAmount = parseInt(inputTopUpAmountRequired.value);
	var estimateAmount = parseInt(e.value);
	if (isParent) {
		if (!isNaN(estimateAmount) && estimateAmount > 0) {
			$("#inputTopUpAmountRequired").attr('readonly', false);
			if (!isNaN(requiredAmount) && requiredAmount > 0) {
				if ((requiredAmount + old_adv_amount + sum_of_old_top) > (.80 * estimateAmount)) {
					inputTopUpAmountRequired.value = ((.80 * estimateAmount) - (old_adv_amount + sum_of_old_top)).toFixed(0);
				}
			}
		}
		else {
			$("#inputTopUpAmountRequired").attr('readonly', true);
			inputAdvanceRequired.value = 0;
		}
	}
	else {
		if (!isNaN(estimateAmount) && estimateAmount > 0) {
			$("#inputTopUpAmountRequired").attr('readonly', false);
			if (!isNaN(requiredAmount) && requiredAmount > 0) {
				if ((requiredAmount + old_adv_amount + sum_of_old_top) > estimateAmount) {
					inputTopUpAmountRequired.value = (estimateAmount - (old_adv_amount + sum_of_old_top)).toFixed(0);
				}
			}
		}
		else {
			$("#inputTopUpAmountRequired").attr('readonly', true);
			inputTopUpAmountRequired.value = 0;
		}

	}



}
function ReviseTopUpAmountRequired_click(e) {

	calculate_claim_amount_for_top_up();
	// debugger;
	var requiredAmount = parseInt(e.value);
	var estimateAmount = parseInt(inputReviseEstimateAmount.value);
	if (isParent) {
		if (!isNaN(requiredAmount) && requiredAmount > 0) {
			if ((requiredAmount + old_adv_amount + sum_of_old_top) > (.80 * estimateAmount)) {
				inputTopUpAmountRequired.value = ((.80 * estimateAmount) - (old_adv_amount + sum_of_old_top)).toFixed(0);
				swal({
					title: 'Invalid !',
					text: 'More than 80% of Estimated Amount is not allowed',
					type: 'error'
				});
			}
		}
	}
	else {
		if (!isNaN(requiredAmount) && requiredAmount > 0) {
			if ((requiredAmount + old_adv_amount + sum_of_old_top) > estimateAmount) {
				inputTopUpAmountRequired.value = (estimateAmount - (old_adv_amount + sum_of_old_top)).toFixed(0);;
				swal({
					title: 'Invalid !',
					text: 'More than Estimated Amount is not allowed',
					type: 'error'
				});
			}
		}
	}


}
function calculate_claim_amount_for_top_up() {
	sum_of_old_top = 0;
	old_adv_amount = parseInt($("#spanApprovedAmount").html());
	for (let e of topUpDataDetails) {
		sum_of_old_top += e.ApprovedTopUpAmount;
	}
}

function HospitalEmpanelledTopUp_Click(e, type) {
	if (type == 'Yes') {
		$("#divSelectHospitalTopUp").css('display', 'block');
		$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'none');


	}
	else {
		$("#divSelectHospitalTopUp").css('display', 'none');
		$("#divHospitalAccountDetailsNotEmpenlled").css('display', 'block');

	}
}