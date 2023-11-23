var empId = 3;
var isParent = false;
var AdvanceId = 0;
var topUpDataDetails = [];
var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [], ReviseEstimateAmount :[]}

var rupee = new Intl.NumberFormat('en-IN', {
    style: 'currency',
    currency: 'INR',
});
// Summary Veriables start
var trFHB = document.getElementById('trFHB');
var trAA = document.getElementById('trAA');
var trPHB = document.getElementById('trPHB');
var trTB = document.getElementById('trTB');
var trDP = document.getElementById('trDP');
//var trBC = document.getElementById('trBC');

var trNT = document.getElementById('trNT');
var trAT = document.getElementById('trAT');
var trBC = document.getElementById('trBC');//May be Negative
var trAmountReturn = document.getElementById('trAmountReturn');
var trNCA = document.getElementById('trNCA');

var tdFHB = document.getElementById('tdFHB');
var tdAA = document.getElementById('tdAA');
var tdPHB = document.getElementById('tdPHB');
var tdTB = document.getElementById('tdTB');
var tdDP = document.getElementById('tdDP');
//var tdBC = document.getElementById('tdBC');

var tdNT = document.getElementById('tdNT');
var tdAT = document.getElementById('tdAT');

var tdBC = document.getElementById('tdBC');
var tdAmountReturn = document.getElementById('tdAmountReturn');
var tdNCA = document.getElementById('tdNCA');


var btnNegativePayment = document.getElementById('btnNegativePayment');


// Summary Veriables ends
// Upload Multiple JavaScript start
var IsNotInBill = false;
var IsPreHosPitlization = false;
var Rowindex = 1;
var selectedIndex = 1;
var uploadType = '';
var uploadKey = '';
var uploadTypeNotInBill = '';
var uploadKeyNotInBill = '';
var uploadIndexNotInBill = 0;
var uploadTypePreHosPitlization = '';
var uploadKeyPreHosPitlization = '';
var fileData = [];
var uploadDetails = { AdmissionAdvice: [], Diagnosis: [], ReviseEstimateAmount: [], EstimateAmount: [], ITRIncomeProof: [], FinalHospitalBill: [], DischargeSummary: [], InvestigationReports: [], RegdCertificate: [], ExemptionLetter:[] };
//{ index:1,row:r, type:Medicine ,uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone)}
var uploadDetailsNotInBill = { Medicine: [], Consultation: [], Investigation: [], Other: [], RoomRent: [] };
var AmountDetailsNotInBill = { Medicine: { count: 0, amount: 0, rowIndex: -1 }, Consultation: { count: 0, amount: 0, rowIndex: -1 }, Investigation: { count: 0, amount: 0, rowIndex: -1 }, Other: { count: 0, amount: 0, rowIndex: -1 }, RoomRent: { count: 0, amount: 0, rowIndex: -1 } };
var uploadDetailsPreHospitlization = { Medicine: [], Consultation: [], Investigation: [], Other: [] };
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
function loadUploadedFileNotInBill(key, index) {
    var row = '';
    let count = 1;
    if (uploadDetailsNotInBill[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsNotInBill[key]) {
        if (e.index == index) {
            row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${key}
                                           
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
                    <i onclick="delete_fileNotInBill(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        }

        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function loadUploadedFilePreHospitlization(key) {
    var row = '';
    let count = 1;
    if (uploadDetailsPreHospitlization[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsPreHospitlization[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadTypePreHosPitlization}
                                           
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
                    <i onclick="delete_filePreHospitlization(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}

function getUploadedElementByKeyAndIndex(key, index) {
    for (var e of uploadDetailsNotInBill[key]) {
        if (e.index == index)
            return e;
    }
}

function previewImgs(event) {
    if (IsNotInBill) {
        previewImgsNotInBill(event)
        return;
    }
    if (IsPreHosPitlization) {
        previewImgsPreHospitlization(event);
        return;
    }

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetails[uploadKey].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    
    imgUpload.value = null;
    loadUploadedFile(uploadKey);
}
function previewImgsNotInBill(event) {

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;
    uploadDetailsNotInBill[uploadKeyNotInBill].push({ index: selectedIndex, type: uploadKeyNotInBill, uploadedFile: clone, billAmount: 0, clientPath: URL.createObjectURL(clone) });
    $("#span" + uploadKeyNotInBill + selectedIndex).html(uploadDetailsNotInBill[uploadKeyNotInBill].length);
    imgUpload.value = null;
    loadUploadedFileNotInBill(uploadKeyNotInBill, selectedIndex);
}
function previewImgsPreHospitlization(event) {

    debugger;
    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    debugger;
    $("#spanPre" + uploadKeyPreHosPitlization).html(uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].length);
    imgUpload.value = null;
    loadUploadedFilePreHospitlization(uploadKeyPreHosPitlization);
}

function getAmount(uploadKey, uploadIndexNotInBill) {
    var e = document.getElementById(uploadKey + uploadIndexNotInBill.toString());
    if (e)
        return e.value;
}

function delete_file(index) {
    uploadDetails[uploadKey].splice(index, 1);
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    loadUploadedFile(uploadKey);
}
function delete_fileNotInBill(index) {
    uploadDetailsNotInBill[uploadKeyNotInBill].splice(index, 1);
    $("#span" + uploadKeyNotInBill + uploadIndexNotInBill).html(uploadDetailsNotInBill[uploadKeyNotInBill].length);
    loadUploadedFileNotInBill(uploadKeyNotInBill, index);
}
function delete_filePreHospitlization(index) {
    uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].splice(index, 1);
    $("#spanPre" + uploadKeyPreHosPitlization).html(uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].length);
    loadUploadedFilePreHospitlization(uploadKeyPreHosPitlization);
}

function TrigerModalUploadFile(type, type2) {
    IsNotInBill = false;
    IsPreHosPitlization = false;
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFile(type2);
}
function TrigerModalUploadFileNotInBill(type, type2, index) {
    IsNotInBill = true;
    IsPreHosPitlization = false;
    uploadTypeNotInBill = type;
    uploadKeyNotInBill = type2;
    uploadIndexNotInBill = index;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    selectedIndex = index;
    loadUploadedFileNotInBill(type2, index);

}
function TrigerModalUploadFilePreHospitlization(type, type2) {
    IsNotInBill = false;
    IsPreHosPitlization = true
    uploadTypePreHosPitlization = type;
    uploadKeyPreHosPitlization = type2;

    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFilePreHospitlization(type2);
}

function NotInBill_cilck(e, type, typeKey) {
    //var newObject = { index: medicineCount, row: e, type: type, uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone) }
    if (AmountDetailsNotInBill[type].count == 1) {
        alert('Please add sum of all other ' + type + ' bill amount into given input box and uoload all files one by one. ');
        return;
    }
    AmountDetailsNotInBill[type].count++;
    AmountDetailsNotInBill[type].rowIndex = Rowindex;
    // Below Code Delete td
    //<td>
    //    <button class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File</button>
    //</td>
    var element = `<tr data-key="${typeKey}" data-index="${Rowindex.toString()}" id="trid">
                            <td></td>
                            <td>${type}</td>

                            <td>
                                <input id="${typeKey + Rowindex.toString()}" onfocusout="other_bill_change(this,'${type}','${typeKey}','${Rowindex}')" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <label class="col-sm-12 col-form-label notinclude"> Not included in Final Bill</label>
                            </td>
                            <td>
                                <button onclick="TrigerModalUploadFileNotInBill('${type}','${typeKey}','${Rowindex}')" type="button" class="btn"><i class="fa fa-upload" aria-hidden="true"></i> Upload File<span id="span${typeKey}${Rowindex}" class="file-status">0</span></button>
                            </td>

                            
                            <td>
                                <button onclick="delete_bill(this,'${typeKey}','${Rowindex.toString()}')" type="button" class="btn"><i class="fa fa-trash" aria-hidden="true"></i></i> Delete</button>
                            </td>

                        </tr>`;
    $('#tbody' + typeKey).append(element);
    Rowindex++;

}

//Upload Code Ends

//Global Declartion
//var spanTotalLimit = document.getElementById('spanTotalLimit');
var tdPatientName = document.getElementById('tdPatientName');
var tdPatientRelation = document.getElementById('tdPatientRelation');
var tdDateOfBirth = document.getElementById('tdDateOfBirth');
var tdGender = document.getElementById('tdGender');

//var tdMale = document.getElementById('tdMale');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegNo = document.getElementById('inputHospitalRegNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputActualDateOfAdmission = document.getElementById('inputActualDateOfAdmission');
var inputEstimatedAmount = document.getElementById('inputEstimatedAmount');
var inputApprovedAmount = document.getElementById('inputApprovedAmount');
var inputReviseEstimateAmount = document.getElementById('inputReviseEstimateAmount');
var inputTopUpAmountRequired = document.getElementById('inputTopUpAmountRequired');
var spanTotalAdvance = document.getElementById('spanTotalAdvance');
//var spanNumber = document.getElementById('spanNumber');
var inputBankName = document.getElementById('inputBankName');
var inputIFSC = document.getElementById('inputIFSC');
var inputBeneficiaryName = document.getElementById('inputBeneficiaryName');
//var inputBeneficiaryName = document.getElementById('inputBeneficiaryName');
var inputConfirmAccountNo = document.getElementById('inputConfirmAccountNo');
var inputDateOfDischarge = document.getElementById('inputDateOfDischarge');
var inputFinalHospitalBill = document.getElementById('inputFinalHospitalBill');

var spanTotalLimit = document.getElementById('spanTotalLimit');
var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');
var tdPreHospitlizationTotal = document.getElementById('tdPreHospitlizationTotal');

var spanAmountIncludedMainBill = document.getElementById('spanAmountIncludedMainBill');
var spanAmountNotIncludedMainBill = document.getElementById('spanAmountNotIncludedMainBill');
var spanFinalBill = document.getElementById('spanFinalBill');
var headingBenificieryName = document.getElementById('headingBenificieryName');
var headingAccountNo = document.getElementById('headingAccountNo');
var headingBenificieryName = document.getElementById('headingBenificieryName');
var headingBankName = document.getElementById('headingBankName');
var headingUTRNo = document.getElementById('headingUTRNo');


//Events
$(document).ready(function () {

    //setAdvanceClaimDefaultValue();
    bindTableAdvanceClaim();
   
});

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
                                <input type="button" onclick="settle_click(${this.empId},'${this.patientName}','${this.relation}',${this.advanceId},${this.patientid})" class="btn btn-primary" value="Settle">&nbsp;&nbsp;<input type="button" onclick="topup_click(${this.empId},'${this.patientName}','${this.relation}',${this.advanceId},${this.patientid})" class="btn btn-danger" value="Top Up">
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
//Functions

var divAdvanceTakenDetails = document.getElementById('divAdvanceTakenDetails');
var divClaimForm = document.getElementById('divClaimForm');
var divTopUp = document.getElementById('divTopUp');
var divTopUpEstimate = document.getElementById('divTopUpEstimate');
var divTopUpBankDetails = document.getElementById('divTopUpEstimate');
var cur_relation = '';
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

function TrigerModalViewFileTopUp(type, type2,index) {
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
            <h4 class="card-title mt-1 mb-2"><span>${count+1}.</span>&nbsp; Top Up Details</h4>
            <div class="row">
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Revise Estimate Amount</label>
                        <div class="col-sm-3 estimatemobile">
                            <input id="inputReviseEstimateAmount${count+1}" type="tel" value="${e.ReviseEstimateAmount}" class="form-control amt" placeholder="₹ 1,80,000.00" readonly>
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
            debugger;
            documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
            $("#spanAdmissionAdviceUpload").html(documentDetails.AdmissionAdviceUpload.length);
            documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            $("#spanDiagnosis").html(documentDetails.Diagnosis.length);
            documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            $("#spanEstimateAmount").html(documentDetails.EstimateAmount.length);


            tdPatientName.innerHTML = JsonData.advanceBasicDetails.patientName;
            tdPatientRelation.innerHTML = JsonData.advanceBasicDetails.relation;
            tdDateOfBirth.innerHTML = JsonData.advanceBasicDetails.dateOfBirth;
            tdGender.innerHTML = JsonData.advanceBasicDetails.gender;
            inputHospitalName.value = JsonData.advanceBasicDetails.hospitalName;
            inputDoctorName.value = JsonData.advanceBasicDetails.doctorName;
            inputActualDateOfAdmission.value = JsonData.advanceBasicDetails.likelyDateofAddmission;
            inputEstimatedAmount.value = JsonData.advanceBasicDetails.estimatedAmount;
            inputApprovedAmount.value = JsonData.advanceBasicDetails.claimApprovedAmount;
            headingBenificieryName.innerHTML = JsonData.hospitalAccoundetail.beneficiaryName;
            headingAccountNo.innerHTML = JsonData.hospitalAccoundetail.accountNumber;
            headingBankName.innerHTML = JsonData.hospitalAccoundetail.bankName;
            headingUTRNo.innerHTML = JsonData.hospitalAccoundetail.utrNo;
            //calculateAndDisplayPrice('NA');
            debugger;
            addTopUpDetail(JsonData.topUpDetails);
            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function getAndFillAdvanceApprovedDetailsByAdvanceID(advanceID) {
    var url = apiBaseUrl + "/api/Claim/GetAdvanceDetails/" + advanceID.toString();
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
            $("#spanAdmissionAdviceUpload").html(documentDetails.AdmissionAdviceUpload.length);
            documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            $("#spanDiagnosis").html(documentDetails.Diagnosis.length);
            documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            $("#spanEstimateAmount").html(documentDetails.EstimateAmount.length);


            tdPatientName.innerHTML = JsonData.advanceBasicDetails.patientName;
            tdPatientRelation.innerHTML = JsonData.advanceBasicDetails.relation;
            tdDateOfBirth.innerHTML = JsonData.advanceBasicDetails.dateOfBirth;
            tdGender.innerHTML = JsonData.advanceBasicDetails.gender;
            inputHospitalName.value = JsonData.advanceBasicDetails.hospitalName;
            inputDoctorName.value = JsonData.advanceBasicDetails.doctorName;
            inputActualDateOfAdmission.value = JsonData.advanceBasicDetails.likelyDateofAddmission;
            inputEstimatedAmount.value = JsonData.advanceBasicDetails.estimatedAmount;
            inputApprovedAmount.value = JsonData.advanceBasicDetails.claimApprovedAmount;
            headingBenificieryName.innerHTML = JsonData.hospitalAccoundetail.beneficiaryName;
            headingAccountNo.innerHTML = JsonData.hospitalAccoundetail.accountNumber;
            headingBankName.innerHTML = JsonData.hospitalAccoundetail.bankName;
            headingUTRNo.innerHTML = JsonData.hospitalAccoundetail.utrNo;
            calculateAndDisplayPrice('NA');
            debugger;
            addTopUpDetail(JsonData.topUpDetails);
            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
var isParent = false;
function settle_click(emp_id, patient_name, relation, advanceID,pId) {
    AdvanceId = advanceID
    cur_relation = relation;
    document.getElementById('divPatientDetails').style.display = 'block';
    document.getElementById('divAdvanceTakenDetails').style.display = 'block';
    document.getElementById('divClaimForm').style.display = 'block';
    document.getElementById('divBillDetails').style.display = 'block';
    document.getElementById('divPreHospitlizationDetails').style.display = 'block';
    document.getElementById('divPaymentSummary').style.display = 'block';
    document.getElementById('divDeclaration').style.display = 'block';
    document.getElementById('divTopUp').style.display = 'none';
   

    //var itr = document.getElementById('itr');
    //if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
    //    itr.style.display = 'block';
    //    isParent = true;
    //}
    //else {
    //    itr.style.display = 'none';
    //    isParent = false;

    //}
    getAndFillAdvanceApprovedDetailsByAdvanceID(advanceID);
    ShowHideParentLimit(relation, pId);

}
function ShowHideParentLimit(relation, familyId) {
    if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
        isParent = true;

        getItrDetailsOfParentFromApi(familyId);
    }
    else {
        divParentClaimLimt.style.display = 'none';
        itrParent.style.display = 'none';
        isParent = false;
    }
}
function getItrDetailsOfParentFromApi(familyId) {
    var _url = apiBaseUrl + "​/api/Common/GetITRDetails/" + familyId;
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(_url, success, failour);
    function success(response) {
        var jsonData = response.data;
        if (response.statusCode == 200 && response.message == "ITR Details found.") {
            divParentClaimLimt.style.display = 'block';
            itrParent.style.display = 'block';
            $("#anchorItr2").attr('href', jsonData.itrFilePath);
            spanTotalLimit.innerHTML = jsonData.totalLimit;
            spanUsedLimit.innerHTML = jsonData.usedLimit;
            spanBalanceLimit.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);
        }
        else {
            divParentClaimLimt.style.display = 'none';
            itrParent.style.display = 'none';

            swal({
                title: 'Invalid !',
                text: 'Your Parents Valid ITR Detail is not available with us Please visit profile section and upload valid ITR Details',
                type: 'error'
            });
        }
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
function topup_click(emp_id, patient_name, relation, advanceId,pId) {
    AdvanceId = advanceId;
    cur_relation = relation;

    document.getElementById('divPatientDetails').style.display = 'block';
    document.getElementById('divAdvanceTakenDetails').style.display = 'block';

    document.getElementById('divClaimForm').style.display = 'none';
    document.getElementById('divBillDetails').style.display = 'none';
    document.getElementById('divPreHospitlizationDetails').style.display = 'none';
    document.getElementById('divPaymentSummary').style.display = 'none';
    document.getElementById('divDeclaration').style.display = 'none';


    document.getElementById('divTopUp').style.display = 'block';

    //var itr = document.getElementById('itr');
    //if (cur_relation.toUpperCase().includes('FATHER') || cur_relation.toUpperCase().includes('MOTHER')) {
    //    itr.style.display = 'block';

    //}
    //else {
    //    itr.style.display = 'none';

    //}
    getAndFillAdvanceApprovedAndTopDetailDetailsByAdvanceID(advanceId);
    ShowHideParentLimit(relation, pId);
}
function delete_element_with_type_index(type, index) {
    var i = 0;
    for (let e of uploadDetailsNotInBill[type]) {
        if (e.index == index) {
            uploadDetailsNotInBill[type].splice(i, 1);
            return true;
        }
        i++;
    }
    return false;
}
function delete_row_from_upload_details_not_in_bill(type, index) {
    while (delete_element_with_type_index(type, index));
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;

}
function delete_bill(e, type, index) {
    var i = e.parentNode.parentNode.rowIndex;
    document.getElementById('billdetails').deleteRow(i);
    delete_row_from_upload_details_not_in_bill(type, index);
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;

    calculateAndDisplayPrice(type);
}
function prehospitlization_click(e) {
    var pre1 = document.getElementById('pre1');
    var pre2 = document.getElementById('pre2');
    if (e.checked) {
        pre1.style.display = 'block';
        pre2.style.display = 'block';    }
    else {
        pre1.style.display = 'none';
        pre2.style.display = 'none';       
    }

}
// ApiCallFunctions
//// Amount Details
function calculate_onchange(element, type) {   
    calculateAndDisplayPrice(type)
}
var amountInBill = 0.0;
var amountNotinBill = 0.0;
var preHospitlizationBill = 0.0;
var advancePayment = 10000.0;
var topUp = 0;
var paidByUserAmount = 0;
function getpaidByUserAmount() {

}
function getAdvanceTakenAmount() {
    var amt = $("#spanApprovedAmount").html();
    if (!isNaN(amt))
        return parseInt(amt);
    else
        return 0;
}
function getTopUpTakenAmount() {
    let amt = 0;
    //{ ReviseEstimateAmount: e.reviseEstimentedAmount, RequiredTopUpAmount: e.topRequiredAmount, ApprovedTopUpAmount: e.approvedAmount, ReviseEstimateFiles: path }
    for (var e of topUpDataDetails) {
        amt += e.ApprovedTopUpAmount;
    }
    return;
}
function getTotalApprovedAdvance() {
    return getAdvanceTakenAmount() + getTopUpTakenAmount();
}
function calculateAndDisplayPrice(type) {
    amountInBill = 0.0;
    amountNotinBill = 0.0;
    preHospitlizationBill = 0.0;
    calculateIncudedPrice();//From Here we got amountInBill
    calculateNotIncludedAmount();//From Here we got amountNotinBill
    if (chkPreHospitlization.checked)
        calculatePreHospitlizationBill();//From Here we got amountNotinBill
    getAdvanceTakenAmount();//From Here we got Advance Taken Amount
    getTopUpTakenAmount();//From Here we got Topup Taken Amount

    spanAmountIncludedMainBill.innerHTML = amountInBill;
    spanAmountNotIncludedMainBill.innerHTML = amountNotinBill;
    
   
    var varFHB = parseFloat(inputFinalHospitalBill.value);
    if (isNaN(varFHB))
        varFHB = 0.0;
    var varAA = amountNotinBill;
    var varPHB = preHospitlizationBill;
    if (chkPreHospitlization.checked) {
        trPHB.style.display = '';
        tdPHB.innerHTML = varPHB;
        tdPreHospitlizationTotal.innerHTML = varPHB;
    }
    else {
        trPHB.style.display = 'none';
    }
    var varTB = varFHB + varAA + varPHB;
    var varAT = advancePayment;

    tdFHB.innerHTML = varFHB;
    tdTB.innerHTML = varTB;
    if (amountNotinBill > 0) {
        trAA.style.display = '';
        tdAA.innerHTML = amountNotinBill;
    }
    else {
        trAA.style.display = 'none';
    }

    tdTB.style.display = '';

    tdAT.innerHTML = advancePayment + topUp;
    tdAT.style.display = '';
    if (cur_relation.toLocaleUpperCase().includes('FATHER') || cur_relation.toLocaleUpperCase().includes('MOTHER')) {
        varDP = (varTB * .20);
        tdDP.innerHTML = varDP.toFixed(2);
        varNT = varTB - varDP;
        tdNT.innerHTML = varNT;
        trDP.style.display = '';
        trNT.style.display = '';
    }
    else {
        varNT = varTB;
        trDP.style.display = 'none';
        trNT.style.display = 'none';
    }
    if ((varNT + paidByUserAmount) < varAT) {
        trBC.style.display = '';
        tdBC.innerHTML = varNT - varAT;
        btnNegativePayment.style.display = 'block';
        if (paidByUserAmount > 0) {
            tdAmountReturn.innerHTML = paidByUserAmount;
            trAmountReturn.style.display = '';
        }
        else {
            trAmountReturn.style.display = 'none';
        }

    }
    else {
        trBC.style.display = 'none';
        btnNegativePayment.style.display = 'none';
        if (paidByUserAmount > 0) {
            tdAmountReturn.innerHTML = paidByUserAmount;
            trAmountReturn.style.display = '';
        }
        else {
            trAmountReturn.style.display = 'none';
        }
    }
    tdNCA.innerHTML = varNT + paidByUserAmount - varAT;

    

}
function calculateIncudedPrice() {
    try {
        let p = parseFloat(inputMedicine.value);
        if (isNaN(p)) {
            p = 0
            inputMedicine.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputMedicine.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultation.value);
        if (isNaN(p)) {
            p = 0
            inputConsultation.value = rupee.format(0.00);
        }
        amountInBill += p
    }
    catch {
        inputConsultation.value = 0;
    }
    try {
        let p = parseFloat(inputInvestigation.value);
        if (isNaN(p)) {
            p = 0
            inputInvestigation.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputInvestigation.value = 0.00;
    }
    try {
        let p = parseFloat(inputRoomRentBill.value);
        if (isNaN(p)) {
            p = 0
            inputRoomRentBill.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputRoomRentBill.value = 0;
    }
    try {
        let p = parseFloat(inputOther.value);
        if (isNaN(p)) {
            p = 0
            inputOther.value = 0.00;
        }
        amountInBill += p
    }
    catch {
        inputOther.value = 0.00;
    }



}
function calculateNotIncludedAmount() {
   
    for (let e in AmountDetailsNotInBill) {
        if (AmountDetailsNotInBill[e].rowIndex != -1) {
            amountNotinBill += AmountDetailsNotInBill[e].amount;
        }
    }
}
function calculatePreHospitlizationBill() {
    try {
        let p = parseFloat(inputMedicinePre.value);
        if (p == NaN) {
            p = 0
            inputMedicinePre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputMedicinePre.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultationPre.value);
        if (p == NaN) {
            p = 0
            inputConsultationPre.value = rupee.format(0.00);
        }
        preHospitlizationBill += p
    }
    catch {
        inputConsultationPre.value = 0;
    }
    try {
        let p = parseFloat(inputInvestigationPre.value);
        if (p == NaN) {
            p = 0
            inputInvestigationPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputInvestigationPre.value = 0.00;
    }

    try {
        let p = parseFloat(inputOtherPre.value);
        if (p == NaN) {
            p = 0
            inputOtherPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputOtherPre.value = 0.00;
    }
}

function other_bill_change(element, type, typeKey, Rowindex) {
   // debugger;
    try {
        let p = parseFloat(element.value);
        if (p == NaN) {
            element.value = 0.00;
        }
        else {
            AmountDetailsNotInBill[typeKey].amount = p;
        }

    }
    catch {
        AmountDetailsNotInBill[typeKey].amount = 0;
    }
    calculateAndDisplayPrice(typeKey);

}

function radio_taxable_click(e) {
    if (radioTaxableNo.checked) {
        taxUploadDoc.style.display = 'block';
    }
    else {
        taxUploadDoc.style.display = 'none';
    }
}
function checkboxDeclaration_cick(e) {

    if (e.checked) {
        btnInpatientSubmit.disabled = false;
    }
}

function rbt_self_onchange(e) {
    if (e.value == 'self') {
        divhospitaldetails.style.display = 'none';
        //btnSubmitWithoutBankDetails.style.display = 'block';
    }
    else {
        divhospitaldetails.style.display = 'block';
        //btnSubmitWithoutBankDetails.style.display = 'none';

    }
}

function btnInpatientSubmit_Click(e) {
    alert('We are  going to submit Advance Claim');
    return;
    var date = new Date();
    const formDataNew = new FormData();

    formDataNew.append('IsSpecailDisease', empId);
    formDataNew.append('EmplId', empId);
    formDataNew.append('PatientId', selectMember.value);
    formDataNew.append('RequestSubmittedById', empId);
    formDataNew.append('RequestName', 'FirstAdvance');
    formDataNew.append('AdvanceRequestDate', date.toJSON());
    formDataNew.append('AdvanceAmount', parseInt(inputAdvanceRequired.value));
    formDataNew.append('Reason', 'NA');
    if (radioPaytoSelf.checked) {
        formDataNew.append('PayTo', 'Self');
    }
    else {
        formDataNew.append('PayTo', 'Hospital');
        formDataNew.append('BankName', inputBankName.value);
        formDataNew.append('BeneficiaryAccountNo', inputAccountNo.value);
        formDataNew.append('IFSCCode', inputIFSC.value);
        formDataNew.append('BeneficiaryName', inputBeneficiaryName.value)
    }
    //formDataNew.append('approvalDate', '1980/01/01');
    //formDataNew.append('ApprovedAmount', 0);
    //formDataNew.append('ApprovedById', 18)
    formDataNew.append('HospitalName', inputHospitalName.value)
    formDataNew.append('HospitalRegNo', inputHospitalRegdNo.value)
    formDataNew.append('DateOfAdmission ', (new Date(inputDateOfAdmission.value)).toJSON());
    formDataNew.append('DoctorName', inputDoctorName.value)

    for (var e of uploadDetails.Diagnosis) {
        formDataNew.append('DiagnosisFile', e.uoloadedFile);
    }
    for (var e of uploadDetails.EstimateAmount) {
        formDataNew.append('EstimateAmountFile', e.uoloadedFile);
    }
    for (var e of uploadDetails.AdmissionAdvice) {
        formDataNew.append('AdmissionAdviceFile', e.uoloadedFile);
    }

    formDataNew.append('ClaimTypeId', 1);
    formDataNew.append('StatusId', 1);
    formDataNew.append('UploadTypeId', 1);
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
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
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
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}

var radioPaytoSelf = document.getElementById('radioPaytoSelf');
function topup_submit_click(e) {
    //alert('We are  going to submit topup');
    //alert('Starting');
    debugger;
    var date = new Date();
    const formDataNew = new FormData();

    formDataNew.append('AdvanceId', AdvanceId);
    
    formDataNew.append('EmpId', empId);
    formDataNew.append('ReviseEstimentedAmount', parseInt(inputReviseEstimateAmount.value));
    formDataNew.append('TopRequiredAmount', parseInt(inputTopUpAmountRequired.value));
    
    if (radioPaytoSelf.checked) {
        formDataNew.append('PayTo', 'self');
    }
    else {
        formDataNew.append('PayTo', 'Hospital');
        formDataNew.append('BankName', inputBankName.value);
        formDataNew.append('AccountNumber', inputBeneficiaryName.value);
        formDataNew.append('IfscCode', inputIFSC.value);
        formDataNew.append('BeneficiaryName', inputBeneficiaryName.value);
    }
    for (var e of uploadDetails.ReviseEstimateAmount) {
        formDataNew.append('ReviseEstimateFile.Files', e.uploadedFile);
    }

    formDataNew.append('ReviseEstimateFile.FileComment', 'NA');
   
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
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
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

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}
function inputIFSC_OnFocusOut() {
    var url = apiBaseUrl + "/api​/Common​/IFSCCodeChecker​/" + inputIFSC.value;
    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(url = url, success, failour);
    function success(response) {
        var jsonData = response.data;
        if (response.statusCode == 200) {
            inputBankName.value = jsonData.bank;
            inputBankName.value = jsonData.bank;
        }



        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
var old_adv_amount = 0;
var sum_of_old_top = 0;
var new_topup_amount = 0;
function calculate_claim_amount_for_top_up() {
    old_adv_amount = parseInt(inputApprovedAmount.value);
    for (let e of topUpDataDetails) {
        sum_of_old_top += e.ApprovedTopUpAmount;
    }
}

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
var divtaxable = document.getElementById('divtaxable');

function specialDisease_Click(e, val) {
    if (e.checked && val == 'Yes') {
        $('radioTaxableNo').attr('checked', true);
        divtaxable.style.display = 'none';
        debugger;
        taxUploadDoc.style.display = 'none';

    }
    else {
        $('radioTaxableNo').attr('checked', true);
        divtaxable.style.display = 'block';
        taxUploadDoc.style.display = 'none';

    }
}

var radioSpecialDiseaseYes = document.getElementById('radioSpecialDiseaseYes');
var radioTaxableNo = document.getElementById('radioTaxableNo');
var checkboxDeclaration = document.getElementById('checkboxDeclaration');
var inputMedicine = document.getElementById('inputMedicine');
var inputConsultation = document.getElementById('inputConsultation');
var inputInvestigation = document.getElementById('inputInvestigation');
var inputRoomRentBill = document.getElementById('inputRoomRentBill');

var inputDateOfDischarge = document.getElementById('inputDateOfDischarge');

var chkPreHospitlization = document.getElementById('chkPreHospitlization');
var inputMedicinePre = document.getElementById('inputMedicinePre');
var inputConsultationPre = document.getElementById('inputConsultationPre');
var inputInvestigationPre = document.getElementById('inputInvestigationPre');
var inputOtherPre = document.getElementById('inputOtherPre');




function btnAdvanceClaimSubmit_Click(e) {
    //alert('Starting');
    debugger;
    var date = new Date();
    const formDataNew = new FormData();

    formDataNew.append('AdvanceId', AdvanceId);
    formDataNew.append('EmpId', empId);
    formDataNew.append('IsSpecailDisease', radioSpecialDiseaseYes.checked);
    
     //Manage Taxable and send file code
    if (radioTaxableNo.checked) {
        formDataNew.append('IsTaxable', false);

        for (var e of uploadDetails.RegdCertificate) {
            formDataNew.append('RegdCertificateFiles', e.uploadedFile);
        }
        for (var e of uploadDetails.ExemptionLetter) {
            formDataNew.append('ExemptionLetterFiles', e.uploadedFile);
        }
    }
    else {
        formDataNew.append('IsTaxable', true);
        for (var e of uploadDetails.ExemptionLetter) {
            formDataNew.append('HospitalIncomeTaxFile.Files', e.uploadedFile);
        }
        for (var e of uploadDetails.RegdCertificate) {
            formDataNew.append('HospitalRegstrationDetailsFile.Files', e.uploadedFile);
        }


    }
    debugger;
    formDataNew.append('Declaration', checkboxDeclaration.checked);

    for (var e of uploadDetails.DischargeSummary) {
        formDataNew.append('DischargeSummaryUpload', e.uploadedFile);
    }
    for (var e of uploadDetails.InvestigationReports) {
        formDataNew.append('InvestigationReportsUpload', e.uploadedFile);
    }
    formDataNew.append('FinalHospitalBill', parseInt(tdFHB.innerText));
    formDataNew.append('ClaimAmount', parseInt(tdNCA.innerText));
    for (var e of uploadDetails.FinalHospitalBill) {
        formDataNew.append('FinalHospitalBillUpload', e.uploadedFile);
    }
    formDataNew.append('MedicenBill.Amount', parseInt(inputMedicine.value));
    formDataNew.append('MedicenNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Medicine.amount));

    for (var e of uploadDetailsNotInBill.Medicine) {
        formDataNew.append('MedicenNotFinalBill.Files', e.uploadedFile);
    }

    formDataNew.append('Consultation.Amount', parseInt(inputConsultation.value));
    formDataNew.append('ConsultationNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Consultation.amount));

    for (var e of uploadDetailsNotInBill.Consultation) {
        formDataNew.append('ConsultationNotFinalBill.Files', e.uploadedFile);
    }

    formDataNew.append('Investigation.Amount', parseInt(inputInvestigation.value));
    

    formDataNew.append('InvestigationNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Investigation.amount));

    for (var e of uploadDetailsNotInBill.Investigation) {
        formDataNew.append('InvestigationNotFinalBill.Files', e.uploadedFile);
    }
    formDataNew.append('RoomRent.Amount', parseInt(inputRoomRentBill.value));
    //formDataNew.append('RoomRentNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Investigation.amount));//Room rent not allowed for additional billWrong Data

    //for (var e of uploadDetailsNotInBill.RoomRent) {
    //    formDataNew.append('RoomRentNotFinalBill.Files', e.uploadedFile);
    //}

    formDataNew.append('OtherBill.Amount', parseInt(inputOther.value));
   
    formDataNew.append('OtherBillNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Other.amount));

    for (var e of uploadDetailsNotInBill.Other) {
        formDataNew.append('OtherBillNotFinalBill.Files', e.uploadedFile);
    }

    formDataNew.append('DateofDischarge', inputDateOfDischarge.value);

    formDataNew.append('IsPreHospitalizationExpenses', chkPreHospitlization.checked);
    formDataNew.append('PreHospitalizationExpensesMedicine.Amount', parseInt(inputMedicinePre.value));
    // In future Remove Below Update it will be nullable
    for (var e of uploadDetailsPreHospitlization.Medicine) {
        formDataNew.append('PreHospitalizationExpensesMedicine.Files', e.uploadedFile);
    }

    formDataNew.append('PreHospitalizationExpensesConsultation.Amount', parseInt(inputConsultationPre.value));
    // In future Remove Below Update it will be nullable
    for (var e of uploadDetailsPreHospitlization.Consultation) {
        formDataNew.append('PreHospitalizationExpensesConsultation.Files', e.uploadedFile);
    }

    formDataNew.append('PreHospitalizationExpensesInvestigation.Amount', parseInt(inputInvestigationPre.value));
    // In future Remove Below Update it will be nullable
    for (var e of uploadDetailsPreHospitlization.Investigation) {
        formDataNew.append('PreHospitalizationExpensesInvestigation.Files', e.uploadedFile);
    }

    formDataNew.append('PreHospitalizationExpensesOther.Amount', parseInt(inputOtherPre.value));
    // In future Remove Below Update it will be nullable
    for (var e of uploadDetailsPreHospitlization.Other) {
        formDataNew.append('PreHospitalizationExpensesOther.Files', e.uploadedFile);
    }

    
    var _url = apiBaseUrl + "​/api/Claim/AdvanceClaimSettle";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
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
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}