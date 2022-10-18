
if(window.location.pathname.split('/')[4]=="1"){
	document.getElementById("Moto").style.background="#d3d3d3"
}
if(window.location.pathname.split('/')[4]=="2"){
	document.getElementById("Senso").style.background="#d3d3d3"
}
if(window.location.pathname.split('/')[4]=="3"){
	document.getElementById("Mix").style.background="#d3d3d3"
}


$('.Uncheck').click(function(){
	let test = 111;
	let arr = document.getElementsByClassName('card')
	for (let i = 0; i < arr.length; i++) {
		arr[i].style.background = 'white'
		$(arr[i]).attr("disabledCart", "False")
	}
})


$('.Check').click(function(){
	let arr = document.getElementsByClassName('card')
	for (let i = 0; i < arr.length; i++) {
		arr[i].style.background = '#d3d3d3'
		$(arr[i]).attr("disabledCart", "True")
	}
})


// $('.card').click(function(event){
// 	    let element = event.currentTarget
// 		let elementAttr = $(element).attr("disabledCart")
// 		if(elementAttr === "false"){
// 				element.style.background = '#d3d3d3'
// 			    $(element).attr("disabledCart", "true")
// 		}
// 		if(elementAttr === "true"){
// 			element.style.background = 'white'
// 			$(element).attr("disabledCart", "false")
// 		}
// })

//// Backend conenction funtions


let urlContext = "https://localhost:44302/"

//Card Management
$("#buttonSaveExcerciseHistory").click(function(){
 let cards = $('.card')
 let cardsInfoArray = []
 for(let i = 0; i < cards.length;i++){

	let obj = {
		"exId" : $(cards[i]).attr("exid"),
		"disabled": ($(cards[i]).attr("disabledCart").toLowerCase()==="true"),
		"order": i+1
	}
	cardsInfoArray.push(obj)
 }
 let url = urlContext+"api/Exercises/excercise/"+window.location.pathname.split('/')[2];
 restRequest("POST",url,JSON.stringify(cardsInfoArray))
 location.reload()
})


//User management

let id = window.localStorage.getItem('therapistId').split('')
$("#personaldDataSumbit").click(function(){
	let userData = {
		"email" : $('#email').val(),
		"phoneNumber" : $('#phonenumber').val(),
		"street" : $('#street').val(),
		"houseNbr" : $('#houseNbr').val(),
		"postalCode" : $('#postalCode').val(),
		"city": $('#city').val()
	}
	
	console.log(id)
    let url = urlContext+"api/userControllers/edit/personalData/"+id[1]+id[2]
	restRequest("POST",url,JSON.stringify(userData))
	location.reload()
})

$("#changePassword").click(function(){
	let userData = {
		"passOld" : $('#OldPassword').val(),
		"passNew" : $('#NewPassword').val()
	}
    let url = urlContext+"api/userControllers/edit/password/"+id[1]+id[2]
	restRequest("POST",url,JSON.stringify(userData))
	location.href("/")
})



$("#createPatient").click(function(){
	let userData = {
		"id":id[1]+id[2],
		"login":$('#userName').val(),
		"patientPass" : $('#NewPassword').val()
	}
    let url = urlContext+"api/userControllers/create/patient"
	restRequest("POST",url,JSON.stringify(userData))
	location.href("/yourPatients")
})


$("#savePhases").click(function(){
	let switchCointainers = $('.switch-container')
	let switchCointainersInfoArray = []
	for(let i = 0; i < switchCointainers.length;i++){
   
	   let obj = {
		   "PhaseId" : $(switchCointainers[i]).attr("phaseid"),
		   "IsActive": ($(switchCointainers[i]).attr("isavaible").toLowerCase()==="true"),
	   }
	   switchCointainersInfoArray.push(obj)
	}
	let url = urlContext+"api/Exercises/user/exercisephase";
	restRequest("POST",url,JSON.stringify(switchCointainersInfoArray))
	location.reload()
	console.log(success)
   })




function restRequest(type,url,data){
	$.ajax({ 
		type: type,
		contentType: "application/json",
		url: url,
		data:data,
		success: function(data){        
		  console.log(url +"succes")
		}
	 });
}

 