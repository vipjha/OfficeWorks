

//Manage View Files 
var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [] }
var topUpDataDetails = [];
//var topUpDataPath;
//Global Declartion

var spanMemberNotification = document.getElementById("spanMemberNotification");
var spanMemberAdvancePay = document.getElementById("spanMemberAdvancePay");
var spanMemberOther = document.getElementById("spanMemberOther");
var inputAdvanceApprovedHospitalName = document.getElementById("inputAdvanceApprovedHospitalName");
var inputAdavnceApprovedHospitalReg = document.getElementById("inputAdavnceApprovedHospitalReg");
var inputAdvanceApprovedDocterName = document.getElementById("inputAdvanceApprovedDocterName");
var inputAdvancedApprovedLikelyDateOfAdmission = document.getElementById("inputAdvancedApprovedLikelyDateOfAdmission");
var inputAdvancedApprovedEstimateAmout = document.getElementById("inputAdvancedApprovedEstimateAmout");
var inputAdvancedApprovedAdvancedRequested = document.getElementById("inputAdvancedApprovedAdvancedRequested");
var inputAdvancedApprovedApprovedAmount = document.getElementById("inputAdvancedApprovedApprovedAmount");
var inputTopDetailsEstimateAmount = document.getElementById("inputTopDetailsEstimateAmount");
var inputTopUpDetailsAmoutRequired = document.getElementById("inputTopUpDetailsAmoutRequired");
var inputTopUpDetailsApprovedAmount = document.getElementById("inputTopUpDetailsApprovedAmount");
var headingModelName = document.getElementById("heading6ModelName");
var headingModelAccountNo = document.getElementById("heading6ModelAccountNo");
var headingModelBankName = document.getElementById("heading6ModelBankName");
var headingModelUtrNo = document.getElementById("heading6ModelUtrNo");
var headingAdvancedApprovedPatientName = document.getElementById("headingAdvancedApprovedPatientName");
var headingAdvancedApprovedRelationName = document.getElementById("headingAdvancedApprovedRelationName");
var headingAdvancedApprovedDob = document.getElementById("headingAdvancedApprovedDob");
var headingAdvancedApprovedFemale = document.getElementById("headingAdvancedApprovedFemale");
var headingAdvancedApprovedAdvancedDate = document.getElementById("headingAdvancedApprovedAdvancedDate");
var headingAdvancedApprovedRequesteAmount = document.getElementById("headingAdvancedApprovedRequesteAmount");
var headingAdvancedApprovedPendingApproval = document.getElementById("headingAdvancedApprovedPendingApproval");
var headingAdvancedApprovedApprovelDate = document.getElementById("headingAdvancedApprovedApprovelDate");


//Events
$(document).ready(function () {
    bindTableAdvanceApproved();
});
function bindTableAdvanceApproved() {

    var tblAdvanceClaim = $('#tbodyAdvanceApprovedList');
    var url = apiBaseUrl + "/api/Claim/GetAdvanceClaim/" + recipientId;

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

            console.log(response)
            console.log(response.statusCode)

            tblAdvanceClaim.append('');
            var count = 1;

            $.each(response.data, function () {
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
                                 ${this.requestDate}
                                 
                            </td>
                            <td>
                                ${this.advanceAmount}                              
                            
                               <td>
                               <button class="btn btn-success-details" type="button" onclick="advanced_app(${this.empId},'${this.employeeName}','${this.relation}','${this.advanceId}','${this.patientId}')">Details</button>
                              
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
function advanced_app(emp_id, emp_name, emp_relation, advanceId, pId) {
    $("#divAdvanceApprovedDetails").css('display', 'block');
    AdvanceId = advanceId;
    var url = apiBaseUrl + "/api/Claim/GetClaimDetails/" + advanceId;
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
            debugger;
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
            //$("#spanAdvanceRequestedAmount").html(JsonData.advanceBasicDetails.estimatedAmount);
            if (JsonData.topUpDetails.length!=0) {
                IsTopUp = true;
                $("#divApprovedAmount").css('display','block');
                $("#divbankdetails").css('display','block');
                $("#spanApprovedAmount").html(JsonData.advanceBasicDetails.claimApprovedAmount);
                if (JsonData.advanceBasicDetails.payTo.toUpperCase() == "SELF") {
                    $("#divbankdetails").css('display', 'none');
                    //$("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
                    ////$("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
                    //$("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
                    //$("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
                    //$("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
                    //$("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
                    //// Two Field Required
                    //$("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
                    //$("#spanTransactionDate").html(JsonData.hospitalAccoundetail.transactionDate);

                }
                else {
                                       
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

            }
            else {
                IsTopUp = false;
                $("#divApprovedAmount").css('display', 'none');
                $("#divbankdetails").css('display', 'none');
                $("#inputNewEstimatedAmount").val(JsonData.advanceBasicDetails.estimatedAmount);
            }

            $("#spanTreatmentType").html(JsonData.advanceBasicDetails.ctreatmentType);
            $("#spanDiagnosis").html(JsonData.advanceBasicDetails.digonosis);
            $("#spanPayTo").html(JsonData.advanceBasicDetails.payTo);
           
            addTopUpDetail(JsonData.topUpDetails);


            //alert("Hello");
            //console.log(response);
            //var JsonData = response.data;
            //console.log(response.data);
            //console.log(response.data.advanceBasicDetails);
            //// var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [] }
            //documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
            //$("#spanAdmissionAdviceUpload").html(documentDetails.AdmissionAdviceUpload.length);
            ////documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            ////$("#spanDiagnosis").html(documentDetails.Diagnosis.length);
            //documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            //$("#spanEstimateAmount").html(documentDetails.EstimateAmount.length);
            //debugger;
            //if (response.statusCode == 200) {
            //    $('#headingAdvancedApprovedPatientName').html(response.data.advanceBasicDetails.patientName);
            //    $('#headingAdvancedApprovedRelationName').html(response.data.advanceBasicDetails.relation);
            //    $('#headingAdvancedApprovedDob').html(response.data.advanceBasicDetails.dateOfBirth);
            //    $('#headingAdvancedApprovedFemale').html(response.data.advanceBasicDetails.gender);
            //    $('#inputAdvanceApprovedHospitalName').val(response.data.advanceBasicDetails.hospitalName);
            //    $('#inputAdavnceApprovedHospitalReg').val(response.data.advanceBasicDetails.hospitalRegNo);
            //    $('#inputAdvanceApprovedDocterName').val(response.data.advanceBasicDetails.doctorName);
            //    try {
            //        $('#inputAdvancedApprovedLikelyDateOfAdmission').val(response.data.advanceBasicDetails.likelyDateofAddmission);
            //    }
            //    catch {
            //    }
            //    try {
            //        $('#headingAdvancedApprovedAdvancedDate').html(JSON.parse(response.data.advanceBasicDetails.requestedDate).format("DD/MM/YYYY HH:mm"));
            //    }
            //    catch {
            //    }
            //    $('#inputAdvancedApprovedEstimateAmout').val(response.data.advanceBasicDetails.estimatedAmount);
            //    $('#inputAdvancedApprovedAdvancedRequested').val(response.data.advanceBasicDetails.advanceReqAmount);
            //    $('#headingAdvancedApprovedPendingApproval').html(response.data.advanceBasicDetails.claimStatus);
            //    var patientname = document.getElementById("headingAdvancedApprovedPatientName");
            //    patientname.innerText = response.data.advanceBasicDetails.patientName;
            //    var patientrel = document.getElementById("headingAdvancedApprovedRelationName");
            //    patientrel.innerText = response.data.advanceBasicDetails.relation;
            //    var patientdate = document.getElementById("headingAdvancedApprovedDob");
            //    patientdate.innerText = response.data.advanceBasicDetails.dateOfBirth;
            //}
            //else {
            //    $('#headingAdvancedApprovedPatientName').html('');
            //    $('#headingAdvancedApprovedRelationName').html('');
            //    $('#headingAdvancedApprovedDob').html('');
            //    $('#headingAdvancedApprovedFemale').html('');
            //    $('#inputAdvanceApprovedHospitalName').val('');
            //    $('#inputAdavnceApprovedHospitalReg').val('');
            //    $('#inputAdvanceApprovedDocterName').val('');
            //    $('#inputAdvancedApprovedLikelyDateOfAdmission').val('');
            //    $('#inputAdvancedApprovedEstimateAmout').val('');
            //    $('#headingAdvancedApprovedAdvancedDate').html('');
            //    $('#headingAdvancedApprovedRequesteAmount').html('');
            //    $('#headingAdvancedApprovedApprovelDate').html('');
            //    $('#headingAdvancedApprovedPendingApproval').html('');
            //    $('#inputAdvancedApprovedApprovedAmount').html('');
            //}
            //try {
            //    let a = JsonData.topUpDetails.length;
            //}
            //catch {
            //    JsonData.topUpDetails = [];
            //}

            //// alert(JsonData.topUpDetails.length);
            //if (JsonData.topUpDetails.length > 0) {
            //    $('#inputAdvancedApprovedApprovedAmount').val(response.data.advanceBasicDetails.claimApprovedAmount);
            //    $('#inputAdvancedApprovedApprovedAmount').attr('readonly', true);
            //    $('#btnAdvanceApproved').css('display', 'none');
            //    $('#divTopUpApproved').css('display', 'block');
            //}
            //else {
            //    $('#inputAdvancedApprovedApprovedAmount').attr('readonly', false);
            //    $('#btnAdvanceApproved').css('display', 'block');
            //    $('#divTopUpApproved').css('display', 'none');
            //}
            //addTopUpDetail(JsonData.topUpDetails);
            $('.page-loader').hide();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
    ShowHideParentLimit(emp_relation, pId, true);

   
}
var isParent = false;
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
//Events

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
    //debugger;top
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
var itrParent = document.getElementById('itrParent');


var AdvanceId = 0;
var advancedapproved = document.getElementById("advanced_approved");


// ApiCallFunctions
var empId = 4;
var recipientId = 4;//for Finanace
var recipientIdForFinance = 6;//for Finanace bill passing
var senderId = 4;//for Hr1
var claimTypeIdAdvance = 1;//for Hr1
var claimTypeIdTopUp = 4;//for Hr1
var statusId = 21;//for FinanceProcessing Bill Passing
var IsTopUp = false;
var AdvanceApprovedSubmit = document.getElementById('AdvanceApprovedSubmit');
function checkboxDeclaration_cick(e) {

    if (e.checked) {
        AdvanceApprovedSubmit.disabled = false;
    }
    else {
        AdvanceApprovedSubmit.disabled = true;
    }
}
function btnAdvanceApprovedSubmit_Click(e, type) {
    
    const formDataNew = new FormData();
    formDataNew.append('AdvanceId', parseInt(AdvanceId));
    formDataNew.append('SenderId', senderId);
    formDataNew.append('RecipientId', recipientIdForFinance);
    if (IsTopUp) {
        formDataNew.append('ClaimTypeId', claimTypeIdTopUp);
        formDataNew.append('ApprovalAmount', $('#inputApprovedAmount').val());
    }
    else {
        formDataNew.append('ClaimTypeId', claimTypeIdAdvance);
        formDataNew.append('ApprovalAmount', $('#inputApprovedAmount').val());
    }

    formDataNew.append('StatusId', statusId);


   
    var _url = apiBaseUrl + "​/api​/Claim​/SubmitAdvanceProcessDetails";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#AdvanceApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Success !',
                    text: "Your Approval request successfully submited to Finance Team",
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
            $("#AdvanceApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#AdvanceApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}
function inputAdvanceApprovedAmount_OnFocusOut(e) {

    var amt = parseInt(e.value);
    var estimatedAmount = parseInt($('#inputNewEstimatedAmount').val());
    var previousAdvanaceAmount = parseInt($('#inputPreviousApprovedAmount').val());
    if (isNaN(previousAdvanaceAmount) || previousAdvanaceAmount == undefined) {
        previousAdvanaceAmount = 0;
    }
    if (isNaN(amt)) {
        $("#divSubmit").css('display', 'none');  
    }
    else {
        $("#divSubmit").css('display', 'block');
        if (isParent) {
            if (amt > ((estimatedAmount - previousAdvanaceAmount) * .8)) {
                e.value = (estimatedAmount - previousAdvanaceAmount) * .8;
                swal({
                    title: 'Invalid !',
                    text: 'You cant Approved more then 80% for Estimated Amount',
                    type: 'error'
                });
            }
            else {

            }
        }
        else {
            if (amt > (estimatedAmount - previousAdvanaceAmount)) {
                e.value = (estimatedAmount - previousAdvanaceAmount);
                swal({
                    title: 'Invalid !',
                    text: 'You cant Approved more then Estimated Amount',
                    type: 'error'
                });

            }
            else {

            }
        }

    }

 
}