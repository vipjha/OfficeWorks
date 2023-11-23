var recipientId = 6;
var isParent = false;
var AdvanceId = 0;
var topUpDataDetails = [];
var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [], ReviseEstimateAmount: [] }
var billPassApproved = document.getElementById("billPass_approved");
$(document).ready(function () {
    bindTableBillPassing();
});

var spanMemberNotification = document.getElementById("spanMemberNotification");
var spanMemberAdvancePay = document.getElementById("spanMemberAdvancePay");
var spanMemberOther = document.getElementById("spanMemberOther");
var inputBillPassApprovedHospitalName = document.getElementById("inputBillPassApprovedHospitalName");
var inputAdavnceApprovedHospitalReg = document.getElementById("inputAdavnceApprovedHospitalReg");
var inputAdvanceApprovedDocterName = document.getElementById("inputAdvanceApprovedDocterName");
var inputAdvancedApprovedLikelyDateOfAdmission = document.getElementById("inputAdvancedApprovedLikelyDateOfAdmission");
var inputBillPassApprovedEstimateAmout = document.getElementById("inputBillPassApprovedEstimateAmout");
var inputBillPassApprovedAdvancedRequested = document.getElementById("inputBillPassApprovedAdvancedRequested");
var inputAdvancedApprovedApprovedAmount = document.getElementById("inputAdvancedApprovedApprovedAmount");
var inputTopDetailsEstimateAmount = document.getElementById("inputTopDetailsEstimateAmount");
var inputTopUpDetailsAmoutRequired = document.getElementById("inputTopUpDetailsAmoutRequired");
var inputTopUpDetailsApprovedAmount = document.getElementById("inputTopUpDetailsApprovedAmount");
var headingModelName = document.getElementById("heading6ModelName");
var headingModelAccountNo = document.getElementById("heading6ModelAccountNo");
var headingModelBankName = document.getElementById("heading6ModelBankName");
var headingModelUtrNo = document.getElementById("heading6ModelUtrNo");
var headingBillPassApprovedPatientName = document.getElementById("headingBillPassApprovedPatientName");
var headingBillPassApprovedRelationName = document.getElementById("headingBillPassApprovedRelationName");
var headingAdvancedApprovedDob = document.getElementById("headingAdvancedApprovedDob");
var headingBillPassApprovedFemale = document.getElementById("headingBillPassApprovedFemale");
var headingBillPassApprovedAdvancedDate = document.getElementById("headingBillPassApprovedAdvancedDate");
var headingBillPassApprovedRequesteAmount = document.getElementById("headingBillPassApprovedRequesteAmount");
var headingBillPassApprovedPendingApproval = document.getElementById("headingBillPassApprovedPendingApproval");
var headingBillPassApprovedApprovelDate = document.getElementById("headingBillPassApprovedApprovelDate");



// Details for the billPassingTable
function bindBill_app(emp_id, emp_name, emp_relation, claimId, familyId) {
    debugger;
    AdvanceId = claimId;
    var url = apiBaseUrl + "/api/Claim/GetClaimDetails/" + claimId;
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
            //alert("Hello");
            console.log(response);
            var JsonData = response.data;
            console.log(response.data);
            console.log(response.data.advanceBasicDetails);
            // var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [] }
            documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
            $("#spanAdmissionAdviceUpload").html(documentDetails.AdmissionAdviceUpload.length);
            documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            $("#spanDiagnosis").html(documentDetails.Diagnosis.length);
            documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            $("#spanEstimateAmount").html(documentDetails.EstimateAmount.length);
            debugger;
            if (response.statusCode == 200) {
                $('#headingBillPassApprovedEmployeeName').html(emp_name);
                $('#headingBillPassApprovedPatientName').html(response.data.advanceBasicDetails.patientName);
                $('#headingBillPassApprovedRelationName').html(response.data.advanceBasicDetails.relation);
                $('#headingBillPassApprovedDob').html(response.data.advanceBasicDetails.dateOfBirth);
                $('#headingAdvancedApprovedFemale').html(response.data.advanceBasicDetails.gender);
                $('#inputBillPassApprovedHospitalName').val(response.data.advanceBasicDetails.hospitalName);
                $('#inputAdavnceApprovedHospitalReg').val(response.data.advanceBasicDetails.hospitalRegNo);
                $('#inputAdvanceApprovedDocterName').val(response.data.advanceBasicDetails.doctorName);
                $('#inputBillPassApprovedDiagnosis').val(response.data.advanceBasicDetails.Diagnosis);
                $('#inputBillPassApprovedEstimateAmout').val(response.data.advanceBasicDetails.finalHospitalBill);
                $('#inputBillPassApprovedApprovedAmount').val(response.data.advanceBasicDetails.claimApprovedAmount);
                try {
                    $('#inputAdvancedApprovedLikelyDateOfAdmission').val(response.data.advanceBasicDetails.likelyDateofAddmission);
                }
                catch {
                }
                try {
                    $('#headingBillPassApprovedAdvancedDate').html(JSON.parse(response.data.advanceBasicDetails.requestedDate).format("DD/MM/YYYY HH:mm"));
                }
                catch {
                }
                $('#inputBillPassApprovedEstimateAmout').val(response.data.advanceBasicDetails.estimatedAmount);
                $('#inputBillPassApprovedAdvancedRequested').val(response.data.advanceBasicDetails.advanceReqAmount);
                $('#headingBillPassApprovedPendingApproval').html(response.data.advanceBasicDetails.claimStatus);
                var patientname = document.getElementById("headingBillPassApprovedPatientName");
                patientname.innerText = response.data.advanceBasicDetails.patientName;
                var patientrel = document.getElementById("headingBillPassApprovedRelationName");
                patientrel.innerText = response.data.advanceBasicDetails.relation;
                var patientdate = document.getElementById("headingBillPassApprovedDob");
                patientdate.innerText = response.data.advanceBasicDetails.dateOfBirth;
            }
            else {
                $('#headingBillPassApprovedEmployeeName').html('');
                $('#headingBillPassApprovedPatientName').html('');
                $('#headingBillPassApprovedRelationName').html('');
                $('#headingBillPassApprovedDob').html('');
                $('#headingBillPassApprovedFemale').html('');
                $('#inputBillPassApprovedHospitalName').val('');
                $('#inputAdavnceApprovedHospitalReg').val('');
                $('#inputAdvanceApprovedDocterName').val('');
                $('#inputAdvancedApprovedLikelyDateOfAdmission').val('');
                $('#inputBillPassApprovedEstimateAmout').val('');
                $('#headingBillPassApprovedAdvancedDate').html('');
                $('#headingBillPassApprovedRequesteAmount').html('');
                $('#headingBillPassApprovedApprovelDate').html('');
                $('#headingBillPassApprovedPendingApproval').html('');
                $('#inputBillPassApprovedApprovedAmount').html('');
                $('#inputBillPassApprovedDiagnosis').html('');
                $('#inputBillPassApprovedEstimateAmout').html('');
                $('#inputBillPassApprovedApprovedAmount').html('');
            }
            try {
                let a = JsonData.topUpDetails.length;
            }
            catch {
                JsonData.topUpDetails = [];
            }

            // alert(JsonData.topUpDetails.length);
            if (JsonData.topUpDetails.length > 0) {
                $('#inputBillPassApprovedApprovedAmount').val(response.data.advanceBasicDetails.claimApprovedAmount);
                $('#inputBillPassApprovedApprovedAmount').attr('readonly', true);
                $('#btnAdvanceApproved').css('display', 'none');
                $('#divTopUpApproved').css('display', 'block');
            }
            else {
                $('#inputBillPassApprovedApprovedAmount').attr('readonly', false);
                $('#btnAdvanceApproved').css('display', 'block');
                $('#divTopUpApproved').css('display', 'none');
            }
            //addTopUpDetail(JsonData.topUpDetails);
            $('.page-loader').hide();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
    ShowHideParentLimit(emp_relation, familyId);

    billPassApproved.style.display = "block";
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

function TrigerModalViewFile(type, type2) {
    $("#viewModal").modal('show');
    $("#modelTitle").html(type)
    $("#tbodyViewDocuments").empty();
    count = 1;
    debugger;
    for (let e of documentDetails[type2]) {
        let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a traget="_blank" href="${e.pathUrl}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
        $("#tbodyViewDocuments").append(row)
        count++;
    }
    //$('#myModalTitle').html(type);
    //$('#spnComment').html(type);
    //loadUploadedFile(type2);
}

function getItrDetailsOfParentFromApi(familyId) {
    var _url = apiBaseUrl + "​/api/Common/GetITRDetails/" + familyId;
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(url = _url, success, failour);
    function success(response) {
        var jsonData = response.data;
        if (response.statusCode == 200 && response.message == "ITR Details found.") {
            divParentClaimLimt.style.display = 'block';
            itrParent.style.display = 'block';
            $("#anchorItr").attr('href', jsonData.itrFilePath);
            spanClaimApprovedTotalLimit.innerHTML = jsonData.totalLimit;
            spanClaimApprovedUsedLimit.innerHTML = jsonData.usedLimit;
            spanClaimApprovedBalanceLimit.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);
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


function bindTableBillPassing() {
    debugger;
    var tblBillPassingClaim = $('#tbodyBillPassingList');
    var url = apiBaseUrl + "/api/Claim/GetClaimForBillPassingList/" + recipientId.toString();
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
            tblBillPassingClaim.append('');
            var count = 1;
            $.each(response.data, function () {
                // debugger;
                var rowBillPassingClaim = ` <tr>
                            <td>${count}</td>
                            <td>
                                ${this.employeeName}                                
                            </td>

                            <td>
                                ${this.patientName}
                            
                            </td>
                             <td>
                                 ${this.requestDate}
                                 
                            </td>
                            <td>
                                ${this.advanceAmount}
                               
                            </td>
                            
                            <td>
                               <button class="btn btn-success-details" type="button" onclick="bindBill_app(${this.empId},'${this.employeeName}','${this.relation}','${this.claimId}','${this.patientId}')">Details</button>
                            </td>
                        </tr>`;

                tblBillPassingClaim.append(rowBillPassingClaim);
                count++;
            });
            $('.page-loader').hide();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}