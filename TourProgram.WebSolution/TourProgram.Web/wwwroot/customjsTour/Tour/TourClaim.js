//Code to Upload Files Start From Here
var empObject = {};
var uploadType = '';
var uploadKey = '';
var fileData = [];
var uploadDetails = { TourEstimate: [], AccommodationEstimate: [] };
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
    if (!(key in uploadDetails)) {
        uploadDetails[key] = [];
    }
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
    if (!(uploadKey in uploadDetails)) {
        uploadDetails[uploadKey] = [];
    }   
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

//Code to Upload Files Ends  Here
//Code to View Files Starts from  Here
var documentDetails = { TourEstimate: [], AccommodationEstimate: [] }
function TrigerModalViewFile(type, type2) {
    $("#viewModal").modal('show');
    $("#modelTitle").html(type)
    $("#tbodyViewDocuments").empty();
    count = 1;    
    for (let e of documentDetails[type2]) {
        let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e.pathUrl}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
        $("#tbodyViewDocuments").append(row)
        count++;
    }   
}
//Code to View Files Ends  Here


/// Code to Load TourRequest and Its Details Click Start from Here
function getEmployeeListFromOrganization() {
    function getDataFromApi() {
        var datalistApprovers = $('#approvres');
        //alert('Not running Api Call due to Return ');        
        var url = "https://uat.dfccilorganization.services.cetpainfotech.com/api/Organization/GetOrganizationHierarchy";
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
                datalistApprovers.empty();
                var count = 1;
                debugger;
                $.each(response.data, function () {
                    var row = `<option data-code="${this.empCode}" value="${this.empName}(${this.designation
                        })">${this.empName}(${this.designation})</option>`;

                    datalistApprovers.append(row);
                    count++;
                });
               // alert('Data Loded');
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    getDataFromApi();
}
function loadTourRequestedList() {
    //AssociatedDiv: divTourRequestedList
    // tbody id: tbodyTourRequested

    function getDataFromApi() {
        var tbodyTourRequested = $('#tbodyTourRequested');
        //alert('Not running Api Call due to Return ');
        //var url = apiBaseUrl + "/api/TourListing/GetTourRaiseClaimList/" + empObject.empId.toString();
        var url = apiBaseUrl + "/api/TourListing/GetTourRequest/" + empObject.empId.toString();
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
                debugger;
                tbodyTourRequested.empty();
                var count = 1;
                $.each(response.data, function () {
                    
                    let btnText = 'Raise Claim';
                    let statusColorClass = 'badge-success';
                    
                    debugger;
                    if (this.status.toUpperCase().includes('CLARIFICATION') ) {
                        statusColorClass = 'badge-warning';
                        btnText = 'Clarification';
                    }
                    
                    if (this.status.toUpperCase().includes('CLARIFICATION') || this.status.toUpperCase().includes('APPROVED') || this.status.toUpperCase().includes('PAYMENT TRANSFER'))
                    {
                        if (this.tourType != "Tour Request Claim") {

                            var rowTourRequested = `<tr>
                            <td>${count}</td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.requestDate)))}
                            </td>
                            <td>
                                ${this.purposeofTour}
                            </td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.tourStartDate)))}
                            </td>
                            <td>
                                ${this.totalDays}
                            </td>
                            <td>
                                 ${this.source}
                            </td>
                            <td>
                                 ${this.destination}
                            </td>
                            <td class="font-weight-medium"><div class="badge ${statusColorClass}">${this.status}</div></td>

                            <td><button onclick="tourDetails_Click(${this.tourId},'${btnText}')" type="button" id="btnDetails" class="btn btn-primary mb-2">${btnText}</button>
                            <button onclick="tourCancel_Click(${this.tourId})" type="button" id="btnCancel" class="btn btn-primary btn-danger mb-2">Tour Not Availed</button>
                            </td>
                        </tr>`;

                            tbodyTourRequested.append(rowTourRequested);
                            count++;
                        }
                    }
                });
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    getDataFromApi();
}
function setDefaultValueToTentativeTourPlan() {
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    tbodyTentativePlan.empty();
    tbodyTentativePlan.append(` <tr id="trTentativePlan_0">
                            <td>
                                <input id="inputStartDate_0" type="date" class="form-control">
                            </td>
                            <td>
                                <input id="inputFrom_0" type="text" class="form-control">
                            </td>
                            <td>
                                <input id="inputTo_0" type="text" class="form-control">
                            </td>
                            <td>
                                <select id="selectTravelMode_0" class="form-control mode">
                                    <option>Air</option>
                                    <option>Rail</option>
                                    <option>Road</option>

                                </select>
                            </td>
                            <td>
                                <select id="selectClassOfCity_0" class="form-control mode">
                                    <option value="X">X</option>
                                    <option value="Y">Y</option>
                                    <option value="Z">Z</option>

                                </select>
                            </td>
                            <td>
                                <input id="inputTourDetails_0" type="text" class="form-control">
                            </td>
                            <td>
                                <button onclick="btnplus_0_Click(this)" type="button" id="btnplus_0" class="btn btn-primary"><i class="fa fa-plus" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button disabled type="button" id="btnminus_0" class="btn btn-primary"><i class="fa fa-minus" aria-hidden="true"></i></button>
                            </td>

                        </tr>`);
}
function setDefaultvalueOfTourProgram() {
    $("#inputPurposeOfTravel").val('');
    $("#inputSource").val('');
    $("#inputDestination").val('');
    $("#inputTentativeDateOfDeparture").val('');
    $("#inputNumberOfDays").val('');
}
function setDefaultToAdvance() {
    $("#inputTravelEstimate").val(0);
    $("#inputAccommodationEstimate").val(0);
    $("#inputAdvanceRequired").val(0);
    $("#tdTotalEstimate").html(0);
    $("#inputAdvanceRequired").val(0);
    $("#radioAdvanceRequiredYes").prop('checked', false);
    $("#radioAdvanceRequiredNo").prop('checked', true);
    $("#divTourEstimate").css('display', 'none');
}
function loadClarification(tourId) {
    //$("#spanRecivedCommentTranportation")
    //$("#textAreaSendCommentTranportation")

    //$("#spanRecivedCommentAccomodation")
    //$("#textAreaSendCommentAccomodation")

    //$("#spanRecivedCommentDA")
    //$("#textAreaSentCommentDA")

    //$("#spanRecivedCommentLeave")
    //$("#textAreaSentCommentLeave")

}
function btnSubmitClarification_Click(e) {
    alert('We are going to Submit Clarification');
}
var tourIdGlobal = 0;
var tenTativeDateOfTravel = '';
function tourDetails_Click(tourId,type) {
    // alert(type);
    tourIdGlobal = tourId;
    if (type == "Clarification") {
        $("#divRespnseToClarification").css('display', 'block');
        loadClarification(tourId);
        return;
    }
    else {
        $("#divRespnseToClarification").css('display', 'none');
    }
    $("#divApproverDetails").css('display', 'block');
    $("#divTourProgram").css('display', 'block');
    $("#divTransportation").css('display', 'block');
    //$("#divAccommodationDetails").css('display', 'block');
   // $("#divTentativeTourPlan").css('display', 'block');
   // $("#divAdvanceRequired").css('display', 'block');
   // $("#divDeclaration").css('display', 'none');
    function loadApproverDetails(dataApprover) {
        
        $("#spanAdvanceApprovedDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(dataApprover.approvalDate))));

        $("#spanAdvanceApprovedBy").html(dataApprover.approvedBy);
        $("#spanAdvanceDesignation").html('(' + dataApprover.designation + ', ' + dataApprover.department + ')');
        $("#anchorDownloadTourApproval").attr('href', dataApprover.filePath);

    }
    function loadTourProgram(dataTourProgram) {
        $("#inputPurposeOfTravel").val(dataTourProgram.purposeOfTour);
        $("#inputSource").val(dataTourProgram.source);
        $("#inputDestination").val(dataTourProgram.destination);
        tenTativeDateOfTravel = formatDate(new Date(Date.parse(dataTourProgram.tentativeStartDate)));
        $("#inputStartDate_0").attr('min', tenTativeDateOfTravel);
        $("#inputEndDate_0").attr('min', tenTativeDateOfTravel);
        $("#inputTentativeDateOfDeparture").val(formatDate(new Date(Date.parse(dataTourProgram.tentativeStartDate))));
        $("#inputNumberOfDays").val(dataTourProgram.noOfDays);
       
    }
    function getDataFromApiForATourId(tourId) {

        var url = apiBaseUrl + "/api/TourPlan/GetTourDetails/" + tourId.toString();
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
                if (response.data.isAdvanceRequired) {
                    //totalAdvanceRequested = parseInt(response.data.advanceRequired);
                    //totalAdvanceTaken = parseInt(response.data.advanceApprovedAmount);
                    //$("#tdAdvancePaymentDate").css('display', '');
                    //$("#tdAdvanceApprovedBy").css('display', '');
                    //debugger;
                    
                    $("#spanAdvanceApprovedBy2").html(response.data.advanceApprovedBy + "(" + response.data.advanceApprovedDesignation + ", " + response.data.advanceApprovedDepartment + ")");
                    if (response.data.advanceApprovedBy == null || response.data.advanceApprovedBy == undefined || response.data.advanceApprovedBy == '') {
                        //$("#spanAdvancePaymentDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(response.data.advanceApprovedDate))));
                        $("#spanAdvancePaymentDate").html('Date Not Found');
                        $("#spanAdvanceApprovedBy2").html('Name not Found');
                    }
                }
                else {
                    //$("#tdAdvancePaymentDate").css('display', 'none');
                    //$("#tdAdvanceApprovedBy").css('display', 'none');
                    if (response.data.advanceApprovedBy == null || response.data.advanceApprovedBy == undefined || response.data.advanceApprovedBy == '') {
                        $("#spanAdvanceApprovedBy2").html('Name not Found');
                    }
                }

                loadApproverDetails(response.data.approverDetails);
                if (response.data.approverDetails.approvedAmount == '' || response.data.approverDetails.approvedAmount == undefined || response.data.approverDetails.approvedAmount == null)
                    response.data.approverDetails.approvedAmount = 0;
                totalAdvanceTaken = response.data.approverDetails.approvedAmount;
                loadTourProgram(response.data.employeeDetails);
                //loadTentativeTourPlan(response.data.tentativeTourPlans);
               // loadAdvanceValue(response.data.isAdvanceRequired, response.data.travelEstimate, response.data.accommodationEstimate, response.data.advanceRequired);
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });

    }
    getDataFromApiForATourId(tourId);
}
/// Code To maintain Transportation  Starts from Here

var rowIndex = 0;
var count = 1;
function setCountOfTransportation() {
    var c = 1;
    $("#tbodyActualTransportationPlan > tr").each(function () {
        var i = this.id.split('_')[1];
        $("#tdSNo_" + i).html(c);
        c++;
    });
}
var gradeWiseDAAmount = 1250;
function getDAInArray() {
    var arrDADetails = [];
    for (var element of $("#tbodyDA > tr")) {
        var index = element.id.split('_')[1];
        var tDetails = {
            date: '', sourceTime: '', endTime: '', daSlab: 0, totalHoursMinutes: 0, percentageAdmissible:0, amount: 0
        }
        tDetails.date = $("#inputDAStartDate_" + index).val();
        tDetails.sourceTime = $("#inputDAStartTime_" + index).val();
        tDetails.endTime = $("#inputDAEndTime_" + index).val();
        tDetails.daSlab = $("#inputDARate_" + index).val();
        tDetails.percentageAdmissible = $("#tdDAPercentage_" + index).html();
        tDetails.amount = $("#inputDAAmount_" + index).val();
        arrDADetails.push(tDetails);
    }
    return arrDADetails;
}
function updateDAAutomatically(arrDA) {
    var tbodyDA = $("#tbodyDA");
    tbodyDA.empty();
    count = 1;
    var totalDA = 0;
    for (var e of arrDA) {
        //{ startDate: new Date(startDate), startTime:, endDate:, endTime: , Hours: , Minutes: , DAPercentage: , DAAmount: , DAOfTheDay: ) };
        totalDA += e.DAOfTheDay;
        var row = ` <tr id="trodyDA_${count}" >
                            <td id="tdDASn_${count}">${count + 1}</td>
                            <td>
                                <input value=${formatDate_yyyy_mm_dd(e.startDate)} id = "inputDAStartDate_${count}" type = "date" class="form-control" >
                            </td>
                            <td>
                                <input value="${e.startTime}" id="inputDAStartTime_${count}" type="time" class="form-control">
                            </td>
                            <td>
                                <input value="${e.endTime}" id="inputDAEndTime_${count}" type="time" class="form-control">
                            </td>
                            <td>
                                <input value="${e.DAAmount}" id="inputDARate_${count}" type="text" class="form-control">
                            </td>
                               <td>${e.Hours}:${e.Minutes}</td>
                            <td id="tdDAPercentage_${count}">
                                ${e.DAPercentage}
                            </td>
                            <td>
                                <input value="${e.DAOfTheDay}" input id="inputDAAmount_${count}" type="text" class="form-control" value="₹000.00">
                            </td>

                        </tr>`;
        tbodyDA.append(row);
        count++;
    }
    $("#spanTotalDA").html(totalDA);
    setClaimSummary();
}
var lastEndDate = '';
var lastRowIndex = 0;
function limitOnDateOfArrival(rowIndex) {
    var startDate =  $("#inputStartDate_" + rowIndex).val();
    if (startDate != null && startDate != undefined && startDate != '') {
        $("#inputEndDate_" + rowIndex).attr('min', startDate)
    }
    lastEndDate = $("#inputEndDate_" + rowIndex).val();
    lastRowIndex = rowIndex;

    var startTime = $("#inputStartTime_" + rowIndex).val();
    if (startTime != null && startTime != undefined && startTime != '') {
        $("#inputEndTime_" + rowIndex).attr('min', startTime)
    }
    
}
function tentativeDateFocusOut(e) {
    var tDate = e.value;
    if (tDate != null && tDate != undefined && tDate != '') {
        $("#inputStartDate_0").attr('min', tDate)
        $("#inputEndDate_0").attr('min', tDate)
    }
}
function updateDAOnFocusOut(e, rowIndex) {
    limitOnDateOfArrival(rowIndex);
    var i = 0;
    var startDate = '';
    var startTime = ''
    var endDate = '';
    var endTime = '';
    debugger;
    for (var element of $("#tbodyActualTransportationPlan > tr")) {
        var index = element.id.split('_')[1];
        if (i == 0) {
            let stDate = $("#inputStartDate_" + index).val();
            if (IsValidData(stDate)) {
                startDate = new Date(stDate);
            }
            let stTime = $("#inputStartTime_" + index).val();
            if (IsValidData(stTime)) {
                startTime = stTime;
            }
            let eDate = $("#inputEndDate_" + index).val();
            if (IsValidData(eDate)) {
                endDate = new Date(eDate);
            }
            let eTime = $("#inputEndTime_" + index).val();
            if (IsValidData(eTime)) {
                endTime =eTime;
            }
        }
        else {
            let eDate = $("#inputEndDate_" + index).val();
            if (IsValidData(eDate)) {
                endDate = new Date(eDate);
            }
            let eTime = $("#inputEndTime_" + index).val();
            if (IsValidData(eTime)) {
                endTime = eTime;
            }
        }
        i++;
    }
    var arrDA = CalculateDAArray(startDate, startTime, endDate, endTime, gradeWiseDAAmount);
    if (arrDA.length > 0) {
        $("#divDailyAllowance").css('display', 'block');
        $("#divLeaveAvailed").css('display', 'block');
        $("#divAccommodationDetails").css('display', 'block');
        $("#divSummary").css('display', 'block');
        $("#divDocuments").css('display', 'block');
        $("#divDiclaration").css('display', 'block');
        $("#divSubmit").css('display', 'block');

    }
    else {
        $("#divDailyAllowance").css('display', 'none');
        $("#divLeaveAvailed").css('display', 'none');
        $("#divAccommodationDetails").css('display', 'none');
        $("#divSummary").css('display', 'none');
        $("#divDocuments").css('display', 'none');
        $("#divDiclaration").css('display', 'none');
        $("#divSubmit").css('display', 'none');
    }
    updateDAAutomatically(arrDA);
}
function getTranportationDetailsInArray(formDataNew) {
    var arrTransportationDetails = [];
    count = 0;
    for (var element of $("#tbodyActualTransportationPlan > tr")) {
        var index = element.id.split('_')[1];
        var tDetails = { DateOfTravelSource: '', TimeOfTravelSource: '', Source: '', ModeOfTravel: '', DateOfTravelDestination: '', TimeOfTravelDestiNation: '', Destination: '', BilledAmount: 0, ClaimedAmount: 0, TransportationUploadDto : [] }
        tDetails.DateOfTravelSource = $("#inputStartDate_" + index).val();
        tDetails.TimeOfTravelSource = $("#inputStartTime_" + index).val();
        tDetails.Source = $("#inputSource_" + index).val();
        tDetails.ModeOfTravel = $("#selectTravelMode_" + index).val();
        tDetails.DateOfTravelDestination = $("#inputEndDate_" + index).val();
        tDetails.TimeOfTravelDestiNation = $("#inputEndTime_" + index).val();
        tDetails.Destination = $("#inputDestination_" + index).val();
        tDetails.BilledAmount = $("#inputBilledAmount_" + index).val();
        tDetails.ClaimedAmount = $("#inputClaimAmount_" + index).val();
        tDetails.StartFileIndexCount =count;
        for (var e of uploadDetails['BillUploadTransportation_' + index]) {
            formDataNew.append('TransportationUploadDto', e.uploadedFile)
            count++
        }
        tDetails.EndFileIndexCount = count-1;        
        arrTransportationDetails.push(tDetails);
        
    }
    return arrTransportationDetails;
}
function addNewTransportation_Click(e, index) {
    rowIndex++;
    count++;
    var tbodyActualTransportationPlan = $("#tbodyActualTransportationPlan");
    var row = `  <tr id="trActualTransportationPlan_${rowIndex}">
                                <td id="tdSNo_${rowIndex}">${count}</td>
                                <td>
                                    <input min="${lastEndDate}" onfocusout="updateDAOnFocusOut(this,${rowIndex})" id="inputStartDate_${rowIndex}"  type="date" class="form-control">
                                </td>
                                <td>
                                    <input onfocusout="updateDAOnFocusOut(this,${rowIndex})" id="inputStartTime_${rowIndex}"  type="time" class="form-control">
                                </td>
                                <td>
                                <input id="inputSource_${rowIndex}" type="text" class="form-control">
                                </td>
                                <td>
                                    <select id="selectTravelMode_${rowIndex}"  class="form-control">
                                        <option>Select One</option>
                                        <option>Rail</option>
                                        <option>Air</option>
                                        <option>Road</option>
                                    </select>
                                </td>
                                <td>
                                    <input min="${lastEndDate}" onfocusout="updateDAOnFocusOut(this,${rowIndex})" id="inputEndDate_${rowIndex}" type="date" class="form-control">
                                </td>
                                <td>
                                    <input onfocusout="updateDAOnFocusOut(this,${rowIndex})" id="inputEndTime_${rowIndex}" type="time" class="form-control">
                                </td>
                                <td>
                                    <input id="inputDestination_${rowIndex}" type="text" class="form-control">
                                </td>
                                <td>
                                    <input onfocusout="billedAmount_FocusOut(this,${rowIndex})" id="inputBilledAmount_${rowIndex}" type="text" class="form-control" value="₹000.00">
                                </td>
                                <td>
                                    <input onfocusout="claimedAmount_FocusOut(this,${rowIndex})" id="inputClaimAmount_${rowIndex}" type="text" class="form-control" value="₹000.00">
                                </td>
                                <td>
                                    <button type="button" onclick="TrigerModalUploadFile('Bill Upload','BillUploadTransportation_${rowIndex}')" class="btn"><i class="fa fa-upload" aria-hidden="true"></i> Upload Bill<span id="spanBillUploadTransportation_${rowIndex}" class="file-status">0</span></button>
                                </td>
                                <td>
                                    <button onclick="addNewTransportation_Click(this,${rowIndex})"  type="button" class="btn"><i class="fa fa-plus-circle" aria-hidden="true"></i></button>
                                </td>
                                <td>
                                <button onclick="removeTransportation_Click(this,${rowIndex})" type="button" class="btn"><i class="fa fa-minus-circle" aria-hidden="true"></i></button>
                                </td>

                            </tr>`;
    tbodyActualTransportationPlan.append(row);
    setCountOfTransportation();
}
function removeTransportation_Click(e, index) {
    $("#trActualTransportationPlan_" + index).remove();
    setCountOfTransportation();
}
var totalBilledTransportationAmount = 0;
var totalClaimedTransportationAmount = 0;
function calculateAllTotalBillOfTransportation() {
    totalBilledTransportationAmount = 0;
    totalClaimedTransportationAmount = 0;
    
    //var tbodyActualTransportationPlan = $("#tbodyActualTransportationPlan");
    debugger;
    //$("#tbodyActualTransportationPlan > tr").each(function () {
    var i = 0;
    for (var element of $("#tbodyActualTransportationPlan > tr")) {       
        var index = element.id.split('_')[1];
        var amtBilled = parseInt($("#inputBilledAmount_" + index).val());
        var amtClaimed = parseInt($("#inputClaimAmount_" + index).val());
        if (isNaN(amtBilled) || amtBilled == undefined) {
            amtBilled == 0;
            $("#inputBilledAmount_" + index).val(0);
        }
        if (isNaN(amtClaimed) || amtClaimed == undefined) {
            amtClaimed == 0;
            $("#inputClaimAmount_" + index).val(0)
        }
        totalBilledTransportationAmount += amtBilled;
        totalClaimedTransportationAmount += amtClaimed;

    }
    $("#spanSubTotalTransportation").html(totalClaimedTransportationAmount);
    setClaimSummary();
    
    
}

function billedAmount_FocusOut(e, index) {
    var amtBilled = parseInt($("#inputBilledAmount_" + index).val());
    var amtClaimed = parseInt($("#inputClaimAmount_" + index).val());
    if (isNaN(amtBilled) || amtBilled == undefined) {
        amtBilled == 0;
        $("#inputBilledAmount_" + index).val(0);
    }
    if (isNaN(amtClaimed) || amtClaimed == undefined) {
        amtClaimed == 0;
        $("#inputClaimAmount_" + index).val(0)
    }
    calculateAllTotalBillOfTransportation();

}
function claimedAmount_FocusOut(e, index) {
    debugger;
    var amtBilled = parseInt($("#inputBilledAmount_" + index).val());
    var amtClaimed = parseInt($("#inputClaimAmount_" + index).val());
    if (isNaN(amtBilled) || amtBilled == undefined) {
        amtBilled == 0;
        $("#inputBilledAmount_" + index).val(0);
    }
    if (isNaN(amtClaimed) || amtClaimed == undefined) {
        amtClaimed == 0;
        $("#inputClaimAmount_" + index).val(0)
    }
    calculateAllTotalBillOfTransportation();
}
/// Code To maintain Transportation  Ends Here

/// Code To maintain Accomodation  Starts from Here

var rowIndexAccomodation = 0;
var countAccomodation = 1;
function setCountOfAccomodation() {
    var c = 1;
    $("#tbodyActualAccomodationPlan > tr").each(function () {
        var i = this.id.split('_')[1];
        $("#tdSNo_" + i).html(c);
        c++;
    });
}
function getAccomodationDetailsInArray(formDataNew) {
    var arrAccomodationDetails = [];
    count = 0;
    for (var element of $("#tbodyActualAccomodationPlan > tr")) {
        var index = element.id.split('_')[1];
        var tDetails = {
            HotelCity: '', ClassOfCity: '', IsOwnArrangement: '', IsFreeAccommodation: '', HotelName: '', DateOfCheckIn: '', TimeOfCheckIn: '', DateOfCheckOut: '',
            CheckOutTime: '', BilledAmount: 0, ClaimedAmount: 0, arrBill: []
        }
        tDetails.HotelCity = $("#inputLocationName_" + index).val();
        tDetails.ClassOfCity = $("#selectHotelClassOfCity_" + index).val();

        var isOwnArr = false;
        if ($("#selectOwnArrangement_" + index).val() == 'YES')
            isOwnArr = true;
        tDetails.IsOwnArrangement = isOwnArr;


        var isFeeAcc = false;
        if ($("#selectFreeAccomodation_" + index).val() == 'YES')
            isFeeAcc = true;
        tDetails.IsFreeAccommodation = isFeeAcc;

        tDetails.HotelName = $("#inputHotelName_" + index).val();
        tDetails.DateOfCheckIn = $("#inputCheckInDate_" + index).val();
        tDetails.TimeOfCheckIn = $("#inputCheckInTime_" + index).val();

        tDetails.DateOfCheckOut = $("#inputCheckOutDate_" + index).val();
        tDetails.TimeOfCheckOut = $("#inputCheckOutTime_" + index).val();
        tDetails.BilledAmount = parseInt( $("#inputBilledAccomodationAmount_" + index).val());
        tDetails.ClaimedAmount = parseInt($("#inputClaimAccomodationAmount_" + index).val());

        tDetails.StartFileIndexCount = count;
        for (var e of uploadDetails['BillUploadAccomodation_' + index]) {
            formDataNew.append('AccomodationUploadDto', e.uploadedFile)
            count++
        }
        tDetails.EndFileIndexCount = count - 1;
        arrAccomodationDetails.push(tDetails);

    }
    return arrAccomodationDetails;
}
function OwnArrangement_change(e) {
    if (e.value == 'Yes') {

    }
    else {

    }
}
function FreeAccomodation_change(e) {
    //alert(e.value);
}
function addNewAccomodation_Click(e, index) {
    rowIndexAccomodation++;
    countAccomodation++;
    var tbodyActualAccomodationPlan = $("#tbodyActualAccomodationPlan");
    var row = `<tr id="trActualAccomodationPlan_${rowIndexAccomodation}">
                            <td id="tdSNo_${rowIndexAccomodation}">${countAccomodation}</td>
                            <td>
                                <input id="inputLocationName_${rowIndexAccomodation}" type="text" class="form-control">
                            </td>
                            <td>
                                <select id="selectHotelClassOfCity_${rowIndexAccomodation}" class="form-control">
                                    <option>Select One</option>
                                    <option>X</option>
                                    <option>Y</option>
                                    <option>Z</option>
                                </select>
                            </td>
                               <td>
                                <select onchange="OwnArrangement_change(this)" id="selectOwnArrangement_${rowIndexAccomodation}" class="form-control">
                                    <option value="Select One">Select One</option>
                                    <option value="Yes">Yes</option>
                                    <option value="No">No</option>
                                </select>
                            </td>
                            <td>
                                <select onchange="FreeAccomodation_change(this)" id="selectFreeAccomodation_${rowIndexAccomodation}" class="form-control">
                                    <option value="Select One">Select One</option>
                                    <option value="Yes">Yes</option>
                                    <option value="No">No</option>
                                </select>
                            </td>
                           
                            <td>
                                <input id="inputHotelName_${rowIndexAccomodation}" type="text" class="form-control">
                            </td>
                            <td>
                                <input id="inputCheckInDate_${rowIndexAccomodation}" type="date" class="form-control">
                            </td>
                            <td>
                                <input id="inputCheckInTime_${rowIndexAccomodation}" type="time" class="form-control">
                            </td>
                            <td>
                                <input id="inputCheckOutDate_${rowIndexAccomodation}" type="date" class="form-control">
                            </td>
                            <td>
                                <input id="inputCheckOutTime_${rowIndexAccomodation}" type="time" class="form-control">
                            </td>
                            <td>
                                <input onfocusout="inputBilledAmountAccomodation_FocusOut(this,${rowIndexAccomodation})" id="inputBilledAccomodationAmount_${rowIndexAccomodation}" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <input onfocusout="inputClaimedAmountAccomodation_FocusOut(this,${rowIndexAccomodation})" id="inputClaimAccomodationAmount_${rowIndexAccomodation}" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <button type="button" onclick="TrigerModalUploadFile('Bill Details','BillUploadAccomodation_${rowIndexAccomodation}')" class="btn"><i class="fa fa-upload" aria-hidden="true"></i> Upload Bill<span id="spanBillUploadAccomodation_${rowIndexAccomodation}" class="file-status">0</span></button>
                            </td>
                            <td>
                                <button onclick="addNewAccomodation_Click(this,${rowIndexAccomodation})" type="button" class="btn"><i class="fa fa-plus-circle" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button onclick="removeAccomodation_Click(this,${rowIndexAccomodation})" type="button" class="btn"><i class="fa fa-minus-circle" aria-hidden="true"></i></button>
                            </td>
                        </tr>`;
   
    tbodyActualAccomodationPlan.append(row);
    setCountOfAccomodation();
}
function removeAccomodation_Click(e, index) {
    debugger;
    $("#trActualAccomodationPlan_" + index).remove();
    setCountOfAccomodation();
}
var totalBilledAccomodationAmount = 0;
var totalClaimedAccomodationAmount = 0;
function calculateAllTotalBillOfAccomodation() {
    totalBilledAccomodationAmount = 0;
    totalClaimedAccomodationAmount = 0;

    //var tbodyActualTransportationPlan = $("#tbodyActualTransportationPlan");
    debugger;
    //$("#tbodyActualTransportationPlan > tr").each(function () {
    var i = 0;
    for (var element of $("#tbodyActualAccomodationPlan > tr")) {
        var index = element.id.split('_')[1];
        var amtBilled = parseInt($("#inputBilledAccomodationAmount_" + index).val());
        var amtClaimed = parseInt($("#inputClaimAccomodationAmount_" + index).val());
        if (isNaN(amtBilled) || amtBilled == undefined) {
            amtBilled == 0;
            $("#inputBilledAccomodationAmount_" + index).val(0);
        }
        if (isNaN(amtClaimed) || amtClaimed == undefined) {
            amtClaimed == 0;
            $("#inputClaimAccomodationAmount_" + index).val(0)
        }
        totalBilledAccomodationAmount += amtBilled;
        totalClaimedAccomodationAmount += amtClaimed;

    }
    $("#spanSubTotalAccomodation").html(totalClaimedAccomodationAmount);
    setClaimSummary();


}

function inputBilledAmountAccomodation_FocusOut(e, index) {
    var amtBilled = parseInt($("#inputBilledAccomodationAmount_" + index).val());
    var amtClaimed = parseInt($("#inputClaimAccomodationAmount_" + index).val());
    if (isNaN(amtBilled) || amtBilled == undefined) {
        amtBilled == 0;
        $("#inputBilledAccomodationAmount_" + index).val(0);
    }
    if (isNaN(amtClaimed) || amtClaimed == undefined) {
        amtClaimed == 0;
        $("#inputClaimAccomodationAmount_" + index).val(0)
    }
    calculateAllTotalBillOfAccomodation();

}
function inputClaimedAmountAccomodation_FocusOut(e, index) {
    debugger;
    var amtBilled = parseInt($("#inputBilledAccomodationAmount_" + index).val());
    var amtClaimed = parseInt($("#inputClaimAccomodationAmount_" + index).val());
    if (isNaN(amtBilled) || amtBilled == undefined) {
        amtBilled == 0;
        $("#inputBilledAccomodationAmount_" + index).val(0);
    }
    if (isNaN(amtClaimed) || amtClaimed == undefined) {
        amtClaimed == 0;
        $("#inputClaimAccomodationAmount_" + index).val(0)
    }
    calculateAllTotalBillOfAccomodation();
}

/// Leave Code Starts from Here
function radioleave_click(e, type) {
    if (type == 'Yes') {
        $("#divLeaveTable").css('display', 'block');
        
    }
    else {
        $("#divLeaveTable").css('display', 'none');
    }
}

var rowIndexLeave = 0;
var countLeave = 1;
function setCountOfLeave() {
    var c = 1;
    $("#tbodyLeave > tr").each(function () {
        var i = this.id.split('_')[1];
        $("#tdSNo_" + i).html(c);
        c++;
    });
}
function getLeaveDetailsInArray() {
    var arrLeaveDetails = [];
    for (var element of $("#tbodyLeave > tr")) {
        var index = element.id.split('_')[1];
        var tDetails = {
            leaveStartDate: '', leaveEndDate: '', daDeductable: '', amount: 0}
        tDetails.leaveStartDate = $("#inputStartDateLeave_" + index).val();
        tDetails.leaveEndDate = $("#inputEndDateLeave_" + index).val();
        tDetails.daDeductable = true;
        if ($("#selectDADeduct_" + index).val() == "NO")
            tDetails.daDeductable = false;
        //tDetails.daDeductable = $("#selectDADeduct_" + index).val();
        tDetails.amount = $("#inputDeductAmount_" + index).val();
        arrLeaveDetails.push(tDetails);

    }
    return arrLeaveDetails;
}
function addNewLeave_Click(e, index) {
    rowIndexLeave++;
    countLeave++;
    var tbodyLeave = $("#tbodyLeave");
    var row = `<tr id="trLeave_${rowIndexLeave}">
                            <td id="tdSNo_${rowIndexLeave}">${countLeave}</td>
                            <td>
                                <input onfocusout="calculateLeaveAmount_FocousOut(this)" id="inputStartDateLeave_${rowIndexLeave}" type="date" class="form-control">
                            </td>
                            <td>
                                <input onfocusout="calculateLeaveAmount_FocousOut(this)" id="inputEndDateLeave_${rowIndexLeave}" type="date" class="form-control">
                            </td>
                            <td>
                                <select id="selectDADeduct_${rowIndexLeave}" class="form-control">
                                    <option>Yes</option>
                                    <option>No</option>
                                </select>
                            </td>
                            <td>
                                <input readonly id="inputDeductAmount_${rowIndexLeave}" type="text" class="form-control">
                            </td>
                            <td>
                                <button onclick="addNewLeave_Click(this,${rowIndexLeave})" type="button" class="btn"><i class="fa fa-plus-circle" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button onclick="removeLeave_Click(this,${rowIndexLeave})" type="button" class="btn"><i class="fa fa-minus-circle" aria-hidden="true"></i></button>
                            </td>
                        </tr>`;

    tbodyLeave.append(row);
    setCountOfLeave();
}
function calculateLeaveAmount_FocousOut(e) {    
    for (var e of $("#tbodyLeave > tr")) {
        var i = e.id.split('_')[1];
        var startDate = $("#inputStartDateLeave_" + i).val();
        var endDate = $("#inputEndDateLeave_" + i).val();
        if (IsValidData(startDate) && IsValidData(endDate)) {
            var obj = getTimeDiffrence(new Date(startDate), '00:00', new Date(endDate), '00:00');
            var noOfDays = obj.Days + 1;
            $("#inputDeductAmount_" + i).val(noOfDays * gradeWiseDAAmount);
        }
    }
    sumOfLeaveAmount();
}
function removeLeave_Click(e, index) {
    $("#trLeave_" + index).remove();
    setCountOfLeave();
}
function sumOfLeaveAmount() {
    var leave_amt = 0;
    for (var e of $("#tbodyLeave > tr")) {
        var i = e.id.split('_')[1];
        leave_amt += parseInt($("#inputDeductAmount_"+i).val())
    }
    $("#spanleaveTotalAmount").html(leave_amt);
    setClaimSummary();
}
/// Leave Code Ends  Here
var totalAdvanceTaken = 5000;
function setClaimSummary() {
    var total = 0;
    $("#tdTranspotation").html($("#spanSubTotalTransportation").html());
    total += parseInt($("#spanSubTotalTransportation").html());
    $("#tdAccomodation").html($("#spanSubTotalAccomodation").html());
    total += parseInt($("#spanSubTotalAccomodation").html());
    $("#tdDA").html($("#spanTotalDA").html());
    total += parseInt($("#spanTotalDA").html());
    $("#tdLeave").html($("#spanleaveTotalAmount").html());
    total -= parseInt($("#spanleaveTotalAmount").html());
    $("#tdTotal").html(total);
    $("#tdAdvanceTaken").html(totalAdvanceTaken);
    total -= totalAdvanceTaken;
    $("#tdBalance").html(total);
    if (total < 0) {
        $("#trNegativeMessage").css('display', '');
    }
    else {
        $("#trNegativeMessage").css('display', 'none');
    }
}
var btnClaimSubmit = document.getElementById('btnClaimSubmit');

function checkboxDeclaration_cick(e) {
    if (e.checked) {
        btnClaimSubmit.disabled = false;
    }
    else {
        btnClaimSubmit.disabled = true;

    }
}
var gradeData = null;
var empGrade = 'N1';
function getDataFromGradeApi() {
    if (gradeData != null) {
        loadGradeData();
        return;
    }

    //alert('Not running Api Call due to Return ');        
    var url = apiBaseUrl + "/api/TourPlan/GetGradeDetail?lavel=" + empObject.empGrade;
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
            gradeData = { lavel: response.data[0].lavel, X: response.data[0].x, Y: response.data[0].y, Z: response.data[0].z }
            loadGradeData();

            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function loadGradeData() {
    var tbodyGrade = $('#tbodyGrade');
    tbodyGrade.empty();
    var row = `<td>
                                ${gradeData.lavel}
                            </td>
                            <td>
                                ${gradeData.X}
                            </td>
                            <td>
                                  ${gradeData.Y}
                            </td>
                            <td>
                                 ${gradeData.Z}
                            </td>
                        </tr>`;
    tbodyGrade.append(row);
}
function radioAdvanceRequired_Click(e, type) {
   
    
    if (type == "Yes") {
        $("#divGradeDetails").css('display', 'block');
        $("#divTourEstimate").css('display', 'block');
        getDataFromGradeApi();
    }
    else {
        $("#divGradeDetails").css('display', 'none');
        $("#divTourEstimate").css('display', 'none');
    }
}

function calculateEstimate_FocusOut(e) {
    var inputTravelEstimate = document.getElementById('inputTravelEstimate');
    var inputAccommodationEstimate = document.getElementById('inputAccommodationEstimate');
    var amtTravel = parseInt(inputTravelEstimate.value);
    var amtAccomodation = parseInt(inputAccommodationEstimate.value);
    if (isNaN(amtTravel) || amtTravel == undefined || amtTravel == null) {
        inputTravelEstimate.value = 0;
        amtTravel = 0;
    }
    if (isNaN(amtAccomodation) || amtAccomodation == undefined || amtAccomodation == null) {
        inputAccommodationEstimate.value = 0;
        amtAccomodation = 0;
    }
    $("#tdTotalEstimate").html(amtTravel + amtAccomodation);

        
}
function inputAdvanceRequired_focusOut(e) {
    var amt = parseInt(e.value);
    var amtEstimate = $("#tdTotalEstimate").html();
    if (isNaN(amt) || amt == undefined || amt == null) {
        e.value = 0;
        amt = 0;
    }
    if (isNaN(amtEstimate) || amtEstimate == undefined || amtEstimate == null) {
        
        amtEstimate = 0;
    }
    if (amt > amtEstimate) {
        e.value = amtEstimate;
        swal({
            title: 'Invalid !',
            text: "Tour Claimed Amount can't be Greater than Estimated Amount",
            type: 'info'
        });
    }

}
function checkDeclaration_cick(e) {
    if (e.checked) {
        $("#btnTourPlanSubmit").prop('disabled', false);
    }
    else {
        $("#btnTourPlanSubmit").prop('disabled', true);

    }
}

function createPostdataTourPlan() {
    var tourData = [];
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    
    tbodyTentativePlan.find('tr').each(function () {
        var i = this.id.split('_')[1];
        var startDate = document.getElementById('inputStartDate_' + i).value;
        
        var from = document.getElementById('inputFrom_' + i).value;
        
        var to= document.getElementById('inputTo_' + i).value;

        var mode = document.getElementById('selectTravelMode_' + i).value
        var classOfCity = document.getElementById('selectClassOfCity_' + i).value
        
        var tourdetails = document.getElementById('inputTourDetails_' + i).value;
        tourData.push({
            date: startDate,
            from: from,
            to: to,
            travelMode: mode,
            tourDetails: tourdetails,
            classOfCity: classOfCity
        })
        
        //alert(this.id);
    });
    return JSON.stringify(tourData);   
}

//var empId = 1;
//var empLevel = 'N1';
var IsDirectTourRequest = false;
var apiBaseUrl = "https://uat.tourservices.cetpainfotech.com"
function callme(e) {
    debugger;
    var dlist = document.getElementById('approvres');

    alert(e);
}
var financeIdGLobal = 225;// login Id EMPCode 100430
function btnClaimSubmit_Click(e) {
    //alert('We Are Ready to Submit Tour');
   
    /// Write Code to Post Tour Plan
    if (!IsDirectTourRequest) {
        const formDataNew = new FormData();
        formDataNew.append('EmpTourPlanId', parseInt(tourIdGlobal));
        formDataNew.append('EmpId', parseInt(empObject.empId));

        formDataNew.append('RecipentId', parseInt(financeIdGLobal));
        formDataNew.append('PurposeOfTour', $("#inputPurposeOfTravel").val());        
        formDataNew.append('Source', $("#inputSource").val());
        formDataNew.append('Destination', $("#inputDestination").val());

        //formDataNew.append('TypeOfTour', 'Domestic');

       
        formDataNew.append('TantetiveDateOfDeparture', $("#inputTentativeDateOfDeparture").val());
        formDataNew.append('NoOfDays', $("#inputNumberOfDays").val());
        

        var transportationDetailsDtos = getTranportationDetailsInArray(formDataNew);
        formDataNew.append('TransportaionDetailDtos', JSON.stringify(transportationDetailsDtos));

        var accomodationDetailsDtos = getAccomodationDetailsInArray(formDataNew);
        formDataNew.append('AccomodationDetailDto', JSON.stringify(accomodationDetailsDtos));
        //formDataNew.append('Grade', empObject.empGrade);

        var DADetailsDtos = getDAInArray();
        formDataNew.append('DailyAllowanceDto', JSON.stringify(DADetailsDtos));
        if (document.getElementById('radioleaveYes').checked) {
            var leaveDetailsDtos = getLeaveDetailsInArray();
            formDataNew.append('LeaveAvailedDto', JSON.stringify(leaveDetailsDtos));
        }
       
        formDataNew.append('DocumentsAttached.IsApprovedTourProgramme', document.getElementById('checkboxApprovedTourProgramme').checked);
        formDataNew.append('DocumentsAttached.IsTickets_BoardingPass_Bills', document.getElementById('checkboxTicketsBills').checked);
        formDataNew.append('DocumentsAttached.IsHotelBills', document.getElementById('checkboxHotelBills').checked);

        formDataNew.append('ClaimAmount', $("#tdBalance").html()); 
        

        var _url = apiBaseUrl + "​​/api​/Claim​/RaiseClaimRequest";
        _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

        $.ajax({
            type: "POST",
            url: _url,
            data: formDataNew,
            processData: false,
            contentType: false,
            beforeSend: function () {
                $('.page-loader').show();
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
            },
            success: function (response) {

                if (response.statusCode == 201) {
                    swal({
                        title: 'Sucess !',
                        text: 'Tour Claim Request has been Successfully Submitted!',
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
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            },
            error: function (jqXHR, status) {
                $('.page-loader').hide();
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
                swal({
                    title: 'Invalid !',
                    text: jqXHR.responseJSON.message,
                    type: 'error'
                });

            }
        });
    }
}
var ManagerId = 0;
$(document).ready(function () {

    empObject = setEmpObjectFromSessionStorage();
    loadTourRequestedList();
    getEmployeeListFromOrganization();
    $("#input-datalist").change(function () {
        var el = $("#input-datalist")[0];  //used [0] is to get HTML DOM not jquery Object
        var dl = $("#approvres")[0];
        if (el.value.trim() != '') {
            var opSelected = dl.querySelector(`[value="${el.value}"]`);
            ManagerId= opSelected.getAttribute('data-code');
        }
    });

});