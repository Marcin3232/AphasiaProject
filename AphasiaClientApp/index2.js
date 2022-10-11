$('.Uncheck').click(function(){
	let arr = document.getElementsByClassName('card')
	for (let i = 0; i < arr.length; i++) {
		arr[i].style.background = 'white'
		$(arr[i]).attr("disabledCart", false)
	}
})


$('.Check').click(function(){
	let arr = document.getElementsByClassName('card')
	for (let i = 0; i < arr.length; i++) {
		arr[i].style.background = '#d3d3d3'
		$(arr[i]).attr("disabledCart", false)
	}
})


$('.card').click(function(event){
	    let element = event.currentTarget
		let elementAttr = $(element).attr("disabledCart")
		if(elementAttr === "false"){
				element.style.background = '#d3d3d3'
			    $(element).attr("disabledCart", "true")
		}
		if(elementAttr === "true"){
			element.style.background = 'white'
			$(element).attr("disabledCart", "false")
		}
})

//// Backend conenction funtions


let urlContext = "https://localhost:44302/"

//Card Management
$("#buttonSaveExcerciseHistory").click(function(){
 let cards = $('.card')
 let cardsInfoArray = []
 for(let i = 0; i < cards.length;i++){
	let obj = {
		"exId" : $(cards[i]).attr("exid"),
		"disabled": $(cards[i]).attr("disabledCart"),
		"order": i
	}
	cardsInfoArray.push(obj)
 }
 let url = urlContext+"api/Exercises/excercise/"+window.location.pathname.split('/')[2];
 restRequest("POST",url,JSON.stringify(cardsInfoArray))
})


//User management


$("#personaldDataSumbit").click(function(){
	let userData = {
		"email" : $('#email').val(),
		"phoneNumber" : $('#phonenumber').val(),
		"street" : $('#street').val(),
		"houseNbr" : $('#houseNbr').val(),
		"postalCode" : $('#postalCode').val(),
		"city": $('#city').val()
	}
    let url = urlContext+"api/userControllers/edit/personalData/"+3
	restRequest("POST",url,JSON.stringify(userData))
})

$("#changePassword").click(function(){
	let userData = {
		"passOld" : $('#OldPassword').val(),
		"passNew" : $('#NewPassword').val()
	}
    let url = urlContext+"api/userControllers/edit/password/"+3
	restRequest("POST",url,JSON.stringify(userData))
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

 