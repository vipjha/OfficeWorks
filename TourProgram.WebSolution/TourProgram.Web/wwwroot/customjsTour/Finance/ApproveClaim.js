var empObject = {};
var gradeWiseDAAmount = 1250;
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

function loadClaimAndClarificationList() {
    //AssociatedDiv: divTourRequestedList
    // tbody id: tbodyTourRequested
    function getDataFromApi() {
        var tbodyClaimRecived = $('#tbodyClaimRecived');
        var tbodyPendingClarification = $('#tbodyPendingClarification');
        //alert('Not running Api Call due to Return ');        
        var url = apiBaseUrl + "​/api​/TourListing​/GetRaiseClaimBillPassingList​/" + empObject.empId.toString();
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
             
                tbodyClaimRecived.empty();
                tbodyPendingClarification.empty();
                var countClaim = 0;
                var countPending = 0;
                $.each(response.data, function () { 
                    if (this.status.toUpperCase().includes('CLARIFICATION')) {
                        countPending++;
                        var rowClarification = `<tr>
                            <td>${countPending}</td>
                             <td>
                                ${this.empName}
                            </td>
                             <td>
                                ${this.purposeofTour}
                            </td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.requestDate)))}
                            </td>
                           
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.tourStartDate)))}
                            </td>
                            <td>
                                 ${this.source}
                            </td>
                            <td>
                                 ${this.destination}
                            </td>    
                            <td>
                                ${this.totalDays}
                            </td>
                                                 

                            <td><button onclick="tourDetails_Click(${this.tourId},'Clarification')" type="button" id="btnDetails" class="btn btn-primary mb-2">Details</button>
                           
                            </td>
                        </tr>`;
                        tbodyPendingClarification.append(rowClarification);
                        count++;
                    }
                    else {
                        countClaim++;
                        var rowClaim = `<tr>
                        <td>${countClaim}</td>
                            <td>
                                ${this.empName}
                            </td>
                             <td>
                                ${this.purposeofTour}
                            </td>
                    
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.requestDate)))}
                            </td>
                           
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.tourStartDate)))}
                            </td>
                             <td>
                                 ${this.source}
                            </td>
                            <td>
                                 ${this.destination}
                            </td>
                            <td>
                                ${this.totalDays}
                            </td>         
                            

                            <td><button onclick="tourDetails_Click(${this.tourId},'Details')" type="button" id="btnDetails" class="btn btn-primary mb-2">Details</button>
                           
                            </td>
                        </tr>`;
                        tbodyClaimRecived.append(rowClaim);
                        
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
function calculateSumOfApprovedAmount() {
    var totalClaim = 0;
    var totalTransportationAmount = 0;
    for (var e of $("#tbodyTransportation > tr")) {
        var i = e.id.split('_')[1];        
        var amt = parseInt($("#inputTransportationApprovedAmount_" + i).val());
        totalTransportationAmount += amt;
    }
    $("#spanTotalTransportationAmount").html(totalTransportationAmount);

    var totalTransportationAmountClaim = 0;
    for (var e of $("#tbodyTransportation > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#spanTransportationClaimedAmount_" + i).html());
        totalTransportationAmountClaim += amt;
    }
    $("#tdTranspotationClaim").html(totalTransportationAmountClaim);
    totalClaim += totalTransportationAmountClaim;



    var totalAccomodationAmount = 0;
    for (var e of $("#tbodyAccomodationDetails > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#inputAccommodationApprovedAmount_" + i).val());
        totalAccomodationAmount += amt;
    }
    $("#spanTotalAccomodationAmount").html(totalAccomodationAmount);

    var totalAccomodationAmountClaim = 0;
    for (var e of $("#tbodyAccomodationDetails > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#spanAccommodationClaimAmount_" + i).html());
        totalAccomodationAmountClaim += amt;
    }
    $("#tdAccomodationClaim").html(totalAccomodationAmountClaim);
    totalClaim += totalAccomodationAmountClaim;


    var totalDAAmount = 0;
    for (var e of $("#tbodyDA > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#inputDAApprovedAmount_" + i).val());
        totalDAAmount += amt;
    }
    $("#spanTotalDAAmount").html(totalDAAmount);

    var totalDAAmountClaim = 0;
    for (var e of $("#tbodyDA > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#spanDAAmount_" + i).html());
        totalDAAmountClaim += amt;
    }
    $("#tdDAClaim").html(totalDAAmountClaim);
    totalClaim += totalDAAmountClaim;
    





    var totalLeaveAmount = 0;
    for (var e of $("#tbodyLeave > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#inputLeaveApprovedAmount_" + i).val());
        totalLeaveAmount += amt;
    }
    $("#spanTotalLeaveAmount").html(totalLeaveAmount);

    var totalLeaveAmountClaim = 0;
    for (var e of $("#tbodyLeave > tr")) {
        var i = e.id.split('_')[1];
        var amt = parseInt($("#spanLeaveAmount_" + i).html());
        totalLeaveAmountClaim = amt;
    }
    $("#tdLeaveClaim").html(totalLeaveAmountClaim);
    totalClaim -= totalLeaveAmountClaim;
    $("#tdTotalClaim").html(totalClaim);
    $("#tdAdvanceTakenClaim").html(totalAdvanceTaken);

    debugger;
    setClaimSummary();
   
}
var totalAdvanceTaken = 0;
var totalAdvanceRequested = 0;
function setClaimSummary() {
    debugger;
    var total = 0;
    $("#tdTranspotation").html($("#spanTotalTransportationAmount").html());
    total += parseInt($("#spanTotalTransportationAmount").html());
    $("#tdAccomodation").html($("#spanTotalAccomodationAmount").html());
    total += parseInt($("#spanTotalAccomodationAmount").html());
    $("#tdDA").html($("#spanTotalDAAmount").html());
    total += parseInt($("#spanTotalDAAmount").html());
    $("#tdLeave").html($("#spanTotalLeaveAmount").html());
    total -= parseInt($("#spanTotalLeaveAmount").html());
    $("#tdTotal").html(total);
    $("#tdAdvanceTaken").html(totalAdvanceTaken);
    total -= totalAdvanceTaken;
    $("#inputClaimApprovedAmount").val(total);

    var RequestedClaimAmount = parseInt($("#spanClaimRequest").html());
    var ApprovedClaimAmount = parseInt($("#inputClaimApprovedAmount").val());
    debugger;
    if ((ApprovedClaimAmount > RequestedClaimAmount) || (ApprovedClaimAmount <0)) {
        document.getElementById('btnSendforBulkDownload').disabled = true;
    }
    else {
        document.getElementById('btnSendforBulkDownload').disabled = false;
    }

    //$("#tdBalance").html(total);
    //if (total < 0) {
    //    $("#trNegativeMessage").css('display', '');
    //}
    //else {
    //    $("#trNegativeMessage").css('display', 'none');
    //}
}

function calculateApprovedAmount_FocusOut(e) {
    var i = e.id.split('_')[1];
    amt = parseInt(e.value);
    
    if (amt == '' || amt == undefined || amt == null || isNaN(amt)) {
        e.value = 0;
        amt = 0;
    }
    var claimedAmt = parseInt($("#spanTransportationClaimedAmount_" + i).html());
    debugger;
    if (amt > claimedAmt) {
        amt = claimedAmt;
        e.value = amt;
        swal({
            title: 'Warning !',
            text: "You can't Enter Approved Amount Greater than Claimed Amount",
            type: 'warning'
        });
    }
    e.value = amt;
    calculateSumOfApprovedAmount();
   
}
function calculateApprovedAmountAccomodation_FocusOut(e) {
    var i = e.id.split('_')[1];
    amt = parseInt(e.value);

    if (amt == '' || amt == undefined || amt == null || isNaN(amt)) {
        e.value = 0;
        amt = 0;
    }
    var claimedAmt = parseInt($("#spanAccommodationClaimAmount_" + i).html());
    debugger;
    if (amt > claimedAmt) {
        amt = claimedAmt;
        e.value = amt;
        swal({
            title: 'Warning !',
            text: "You can't Enter Approved Amount Greater than Claimed Amount",
            type: 'warning'
        });
    }
    e.value = amt;
    calculateSumOfApprovedAmount();

}
function calculateApprovedAmountDA_FocusOut(e){
    var i = e.id.split('_')[1];
    amt = parseInt(e.value);

    if (amt == '' || amt == undefined || amt == null || isNaN(amt)) {
        e.value = 0;
        amt = 0;
    }
    var claimedAmt = parseInt($("#spanDAAmount_" + i).html());
    debugger;
    if (amt > claimedAmt) {
        amt = claimedAmt;
        e.value = amt;
        swal({
            title: 'Warning !',
            text: "You can't Enter Approved Amount Greater than Claimed Amount",
            type: 'warning'
        });
    }
    e.value = amt;
    calculateSumOfApprovedAmount();

}
function calculateApprovedAmountLeave_FocusOut(e) {
    var i = e.id.split('_')[1];
    amt = parseInt(e.value);

    if (amt == '' || amt == undefined || amt == null || isNaN(amt)) {
        e.value = 0;
        amt = 0;
    }
    var claimedAmt = parseInt($("#spanLeaveAmount_" + i).html());
    debugger;
    if (amt > claimedAmt) {
        amt = claimedAmt;
        e.value = amt;
        swal({
            title: 'Warning !',
            text: "You can't Enter Approved Amount Greater than Claimed Amount",
            type: 'warning'
        });
    }
    e.value = amt;
    calculateSumOfApprovedAmount();

}
function getTransportationDetailsForPost() {
    arrTransportationDetails = [];
    for (var e of $("#tbodyTransportation > tr")) {
        var i = e.id.split('_')[1];
        var obj = { id: parseInt($("#inputTransportationId_" + i).val()), approvedAmount: parseInt( $("#inputTransportationApprovedAmount_" + i).val()) };
        arrTransportationDetails.push(obj);
    }
    return arrTransportationDetails;
}
function getAccomodationDetailsForPost() {
    arrAccomodationDetails = [];
    for (var e of $("#tbodyAccomodationDetails > tr")) {
        var i = e.id.split('_')[1];
        var obj = { id: parseInt($("#inputAccomodationId_" + i).val()), approvedAmount: parseInt($("#inputAccommodationApprovedAmount_" + i).val()) };
        arrAccomodationDetails.push(obj);
    }
    return arrAccomodationDetails;
}
function getDADetailsForPost() {
    arrDADetails = [];
    for (var e of $("#tbodyDA > tr")) {
        var i = e.id.split('_')[1];
        var obj = { id: parseInt($("#inputDAId_" + i).val()), approvedAmount: parseInt($("#inputDAApprovedAmount_" + i).val()) };
        arrDADetails.push(obj);
    }
    return arrDADetails;
}
function getLeaveDetailsForPost() {
    arrLeaveDetails = [];
    for (var e of $("#tbodyLeave > tr")) {
        var i = e.id.split('_')[1];
        var obj = { id: parseInt($("#inputLeaveId_" + i).val()), approvedAmount: parseInt($("#inputLeaveApprovedAmount_" + i).val()) };
        arrLeaveDetails.push(obj);
    }
    return arrLeaveDetails;
}
function radioSeekClarification(e,type) {
    if (type == "Yes") {
        $("#divTableClarification").css('display', 'block');
        $("#divSendforBulkDownload").css('display', 'none');
        
    }
    else {
        $("#divTableClarification").css('display', 'none');
        $("#divSendforBulkDownload").css('display', 'block');
    }
}
function tourDetails_Click(tourId,type) {
    // alert(type);
    tourIdGlobal = tourId;
    if (type == "Clarification") {
        $("#divRespnseToClarification").css('display', 'block');
        loadClarification(tourId);
        return;
    }
    else {
        $("#divEmployeeDetails").css('display', 'block');
        $("#divApproverDetails").css('display', 'block');
        $("#divTransporation").css('display', 'block');
        $("#divAccomodation").css('display', 'block');
        $("#divDailyAllowance").css('display', 'block');
        $("#divLeaveDetails").css('display', 'block');
        $("#divSummary").css('display', 'block');
        $("#divApprovalDetails").css('display', 'block');
        $("#divSendforBulkDownload").css('display', 'block');
        $("#divSeekClarification").css('display', 'block');

    }  
    function loadEmployee(dataEmployee) {
        $("#spanEmployeeNo").html(dataEmployee.employeeNo);
        $("#spanEmployeeName").html(dataEmployee.employeeName);
        $("#spanEmpDesignation").html(dataEmployee.designation);
        $("#spanEmpDepartment").html(dataEmployee.employeeDepartment);
        $("#spanUnits").html(dataEmployee.units);
        $("#spanEmpPurpose").html(dataEmployee.purposeOfTour);
        $("#spanDestination").html(dataEmployee.destination);
        $("#spanSource").html(dataEmployee.source);
        $("#spanTentativeStartDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse( dataEmployee.tentativeStartDate))));
        $("#spanNoOfDays").html(dataEmployee.noOfDays);
       
        
    }
    function loadApproverDetails(dataApprover) {
        $("#spanAdvanceApprovedDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(dataApprover.approvalDate))));

        $("#spanAdvanceApprovedBy").html(dataApprover.approvedBy);
        $("#spanAdvanceDesignation").html('(' + dataApprover.designation + ', ' + dataApprover.department + ')');
        $("#anchorDownloadTourApproval").attr('href', dataApprover.filePath);

    }
    
    function loadTransportationDetails(dataTransportation) {
        var tbodyTransportation = $("#tbodyTransportation");
        tbodyTransportation.empty();
        count = -1;
        for (var e of dataTransportation) {
            count++;
            if (!('ViewBill_'+count in documentDetails)) {
                documentDetails['ViewBill_' + count] = e.bills.map(element => ({ pathUrl: element.filePath, fileName: element.fileName }))
            }
            var docCount = documentDetails['ViewBill_' + count].length;
            var trTransportation = `<tr id="trTransportation_${count}">
                            <td tdSN_${count}>${count + 1}
                                <input id="inputTransportationId_${count}" type="hidden" value="${e.transportationId}">
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanDepartureDate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse( e.departureDate)))}</span >
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanDepartureTime_${count}">${e.departureTime}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanSource_${count}">${e.departureSource_Station}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanModeOfTravel_${count}">${e.departureModeofTravel}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanArrivalDate_0">${formatDate_dd_mm_yyyy(new Date(Date.parse(e.arrivalDate))) }</span>
                                
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanArrivalTime_${count}">${e.arrivalTime}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanDestination_${count}">${e.arrivalDesination}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanTransportationBilledAmount_${count}">${e.billedAmount}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanTransportationClaimedAmount_${count}">${e.claimedAmount}</span>
                            </td>
                            <td>
                                <button onclick="TrigerModalViewFile('Transportation Bill','ViewBill_${count}')" type="button" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File<span id="spanViewBillView_${count}" class="file-status">${docCount}</span></button>
                            </td>
                            <td>
                                <input onfocusout="calculateApprovedAmount_FocusOut(this)" value="${e.claimedAmount}" id="inputTransportationApprovedAmount_${count}" type="text" class="form-control amt-control" value="0">
                            </td>
                            <td>
                                <input id="inputTransportationRemark_${count}" type="text" class="form-control amt-control" value="NA">
                            </td>
                        </tr>`;
            tbodyTransportation.append(trTransportation);
        }
       
    }
   
    function loadAccomodationDetails(dataAccomodation) {
        var tbodyAccomodationDetails = $("#tbodyAccomodationDetails");
        tbodyAccomodationDetails.empty();       
        count = -1;
        for (var e of dataAccomodation) {
            count++;
            if (!('ViewBillAccomodation_' + count in documentDetails)) {
                documentDetails['ViewBillAccomodation_' + count] = e.bills.map(element => ({ pathUrl: element.filePath, fileName: element.fileName }))
            }
            var docCount = documentDetails['ViewBillAccomodation_' + count].length;
            var trAcomodation = `<tr id="trAcomodation_${count}">
                            <td id="tdSn_${count}">${count + 1}
                            <input id="inputAccomodationId_${count}" type="hidden" value="${e.accomodationId}">
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationCity_${count}">${e.location}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodatioClassOfCity_${count}">${e.classofCity}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationOwnArrangement_${count}">${(e.ownArrangement==true)?("Yes"):("No")}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationFree_${count}">${(e.freeAccommodationProvidedbyCompany == true) ? ("Yes") : ("No") }</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationHotelName_${count}">${e.hotelName}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationCheckInDate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse( e.checkInDate)))}</span >
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationCheckInTime_${count}">${e.checkInTime}</span>
                            </td>
                            <td><span class="mb-1 text-start span-text" id="spanAccommodationCheckOutDate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse(e.checkOutDate))) }</span></td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationCheckOutTime_${count}">${e.checkOutTime}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationBilledAmount_${count}">${e.billedAmount}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanAccommodationClaimAmount_${count}">${e.claimedAmount}</span>
                            </td>
                            <td>
                                <input value="${e.claimedAmount}" onfocusout="calculateApprovedAmountAccomodation_FocusOut(this)" type="text" class="form-control amt-control" id="inputAccommodationApprovedAmount_${count}">
                            </td>
                            <td>
                                <input type="text" class="form-control amt-control" id="inputAccommodationRemarks_${count}">
                            </td>
                            <td>
                                <button onclick="TrigerModalViewFile('Accomodation Bill','ViewBillAccomodation_${count}')" type="button" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File<span id="ViewBillAccomodationView_${count}" class="file-status">${docCount}</span></button>
                            </td>
                        </tr>`;
            tbodyAccomodationDetails.append(trAcomodation);
        }
        
    }
   
    function loadDADetails(dataDA) {
        var tbodyDA = $("#tbodyDA");
        tbodyDA.empty();
        count = -1;
        for (var e of dataDA) {
            count++;
            
            var trDA = `<tr id="trDA_${count}">
                                <td tdSNo_${count}>${count + 1}
                                 <input id="inputDAId_${count}" type="hidden" value="${e.daDetailId}">
                                </td>
                                <td>
                                    <span class="mb-1 text-start span-text" id="spanDADate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse(e.date)))}</span >
                                </td>
                                <td>
                                    <span class="mb-1 text-start span-text" id="spanDASourceTime_${count}">${e.sourceTime}</span>
                                </td>
                                <td>
                                    <span class="mb-1 text-start span-text" id="spanDAEndTime_${count}">${e.endTime}</span>
                                </td>
                                <td>
                                    <span class="mb-1 text-start span-text" id="spanDASlab_${count}">${e.dASlab}</span>
                                </td>
                                <td><span class="mb-1 text-start span-text" id="spanDAPercentage_${count}">${e.percentageAdmissible}</span></td>
                                <td><span class="mb-1 text-start span-text" id="spanDAAmount_${count}">${e.amount}</span></td>
                                <td>
                                    <input onfocusout="calculateApprovedAmountDA_FocusOut(this)"  type="text" class="form-control" value="${e.amount}" id="inputDAApprovedAmount_${count}">
                                </td>
                                <td>
                                    <input type="text" class="form-control remarks" id="inputDARemarks_${count}">
                                </td>
                            </tr>`;
            tbodyDA.append(trDA);
        }
        
    }
    
    function loadLeaveDetails(dataLeave) {
        var tbodyLeave = $("#tbodyLeave");
        tbodyLeave.empty();
        count = -1;
        for (var e of dataLeave) {
            count++;

            var trLeave = `<tr id="trLeave_${count}">
                            <td id="tdSNo_${count}">${count + 1}
                             <input id="inputLeaveId_${count}" type="hidden" value="${e.leaveDetailId}">
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanLeaveStartDate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse(e.leaveStartDate)))}</span >
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanLeaveEndDate_${count}">${formatDate_dd_mm_yyyy(new Date(Date.parse(e.leaveEndDate))) }</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanLeaveDADeductable_${count}">${(e.daDeductable)?("Yes"):("No")}</span>
                            </td>
                            <td>
                                <span class="mb-1 text-start span-text" id="spanLeaveAmount_${count}">${e.amount}</span>
                            </td>
                            <td>
                                <input onfocusout="calculateApprovedAmountLeave_FocusOut(this)" value="${e.amount}" type="text" class="form-control" id="inputLeaveApprovedAmount_${count}">
                            </td>
                            <td>
                                <input type="text" class="form-control value="NA" remarks" id="inputLeaveRemarks_${count}">
                            </td>
                        </tr>`;
            tbodyLeave.append(trLeave);
        }
        
    }
    function getDataFromApiForATourId(tourId) {
       // tourId = 68;
        var url = apiBaseUrl + "/api/Claim/RaiseClaimRequest/" + tourId.toString();
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
                    totalAdvanceRequested = parseInt(response.data.advanceRequired);
                    totalAdvanceTaken = parseInt(response.data.advanceApprovedAmount);
                    $("#tdAdvancePaymentDate").css('display', '');
                    $("#tdAdvanceApprovedBy").css('display', '');
                    debugger;
                    $("#spanAdvancePaymentDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(response.data.advanceApprovedDate))));
                    $("#spanAdvanceApprovedBy2").html(response.data.advanceApprovedBy + "(" + response.data.advanceApprovedDesignation + ", " + response.data.advanceApprovedDepartment + ")");
                    if (response.data.advanceApprovedBy == null || response.data.advanceApprovedBy == undefined || response.data.advanceApprovedBy == '') {
                        $("#spanAdvanceApprovedBy2").html('Name not Found');
                    }
                }
                else {
                    $("#tdAdvancePaymentDate").css('display', 'none');
                    $("#tdAdvanceApprovedBy").css('display', 'none');
                    if (response.data.advanceApprovedBy == null || response.data.advanceApprovedBy == undefined || response.data.advanceApprovedBy == '') {
                        $("#spanAdvanceApprovedBy2").html('Name not Found');
                    }
                }

                
                $("#spanClaimRequest").html(response.data.claimAmount);
                loadEmployee(response.data.empTourDetails)
                loadApproverDetails(response.data.tourApprovelDetails.approverDetails);
                loadTransportationDetails(response.data.transportationList);
                loadAccomodationDetails(response.data.accommodationList);
                loadDADetails(response.data.dailyAllowancList);
                loadLeaveDetails(response.data.leaveList);
                calculateSumOfApprovedAmount();
                
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

var apiBaseUrl = "https://uat.tourservices.cetpainfotech.com"

var financeIdGLobal = 225;// login Id EMPCode 100430

function btnSendforBulkDownload_Click(e) {
    alert('Post Under processing');
    var objPostObject = {
        approveTransportation: getTransportationDetailsForPost().map(e => ({
            transportationId: e.id,
            transportationAmount: e.approvedAmount
        })),
        approveAccommodation: getAccomodationDetailsForPost().map(e => ({
            accommodationId: e.id,
            accommodationAmount: e.approvedAmount
        })),
        approveDailyAllowanc: getDADetailsForPost().map(e => ({
            dailyAllowancId: e.id,
            dailyAllowancAmount: e.approvedAmount
        })),
        approveLeave: getLeaveDetailsForPost().map(e => ({
            leaveId: e.id,
            leaveAmount: e.approvedAmount
        }))
    };
    var _url = apiBaseUrl + "​​​/api​/Claim​/ApproveRaiseClaimAmount​/" + tourIdGlobal.toString() + "/" + empObject.empId.toString() + "/" + $("#inputClaimApprovedAmount").val();
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    debugger;
    $.ajax({
        type: "PUT",
        url: _url,
        data: JSON.stringify(objPostObject),
        contentType: 'application/json',
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Success !',
                    text: "Approval amount is updated successfully and transferred for bulk download",
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
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });
}


$(document).ready(function () {

    empObject = setEmpObjectFromSessionStorage();
    loadClaimAndClarificationList();
    
});