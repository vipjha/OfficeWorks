var gender = '';
var empId = 3;
$(document).ready(function () {
	BindAllClaimClarificationRequest();
});

function BindAllClaimClarificationRequest() {
	$('#leftUser').empty();
	$('#rightUser').empty();
	var divleftUser = $('#leftUser');
	var divrightUser = $('#rightUser');

	$.ajax({
		type: "POST",
		url: apiBaseUrl + "/api/Claim/GetBillClarificationRequest/" + empId.toString(),
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
			divleftUser.empty();
			divrightUser.empty();
			var count = 0;
			var senderRequestDate = '';
			var senderMessage = '';
			var reciverRequestDate = '';
			var reciverMessage = '';
			$.each(response.data, function () {

				$.each(response.data[count].senderDetails, function () {
					if (senderMessage != this['message'] && senderRequestDate != this['requestDate']) {
						var htmlContent = `<li class='left clearfix'>
                                <span class="chat-img1 pull-left">
                                    <img src='/images/logo.png' alt='User Avatar' class='img-circle'>
                                </span>
                                <div class='chat-body1 clearfix'>
                                    <p>`+ this['message'] + `</p>
                                    <div class='chat_time pull-right'>`+ this['requestDate'] + `</div>
                                </div></li>`
						divleftUser.append(htmlContent);
						senderRequestDate = this['requestDate'];
						senderMessage = this['message'];
					}
				});

				$.each(response.data[count].reciverDetails, function () {
					if (reciverMessage != this['message'] && reciverRequestDate != this['requestDate']) {
						var htmlContent = `<li class="left clearfix admin_chat">
                                <span class="chat-img1 pull-right">
                                    <img src="/images/logo.png" alt="User Avatar" class="img-circle">
                                </span>
                                <div class="chat-body1 clearfix">
                                    <p>`+ this['message'] + `</p>
                                    <div class="chat_time pull-left">`+ this['requestDate'] + `</div>
                                </div>
                            </li>`
						divrightUser.append(htmlContent);
						reciverRequestDate = this['requestDate'];
						reciverMessage = this['message'];
					}
				});
				count++;
				//if (this['relation'] != 'Self') {


				//	var htmlContent = `'<tr>
				//	<td> `+ this['memberName'] + `</td>
				//                    <td>`+ this['relation'] + `</td>
				//                    <td class="text-center">`+ this['dob'] + `</td>
				//                    <td class="text-center">`+ this['age'] + `</td>
				//                    <td class="text-center">`+ this['gender'] + `</td>
				//		`+ itrView + `

				//                </tr>'`;

				//	ddlEmployeerelation.append(htmlContent);
				//}
			});
			$('.page-loader').hide();

		},
		failure: function (response) {
			alert(response.d);
		}
	});
}


