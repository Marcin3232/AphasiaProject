(()=>{$(".Uncheck").click((function(){let t=document.getElementsByClassName("card");for(let e=0;e<t.length;e++)t[e].style.background="white",$(t[e]).attr("disabledCart",!1)})),$(".Check").click((function(){let t=document.getElementsByClassName("card");for(let e=0;e<t.length;e++)t[e].style.background="#d3d3d3",$(t[e]).attr("disabledCart",!1)})),$(".card").click((function(t){let e=t.currentTarget,a=$(e).attr("disabledCart");"false"===a&&(e.style.background="#d3d3d3",$(e).attr("disabledCart","true")),"true"===a&&(e.style.background="white",$(e).attr("disabledCart","false"))}));function t(t,e,a){$.ajax({type:t,contentType:"application/json",url:e,data:a,success:function(t){console.log(e+"succes")}})}$("#buttonSaveExcerciseHistory").click((function(){let e=$(".card"),a=[];for(let t=0;t<e.length;t++){let l={exId:$(e[t]).attr("exid"),disabled:$(e[t]).attr("disabledCart"),order:t};a.push(l)}t("POST","https://localhost:44302/api/Exercises/excercise/"+window.location.pathname.split("/")[2],JSON.stringify(a))})),$("#personaldDataSumbit").click((function(){location.reload()})),$("#changePassword").click((function(){let e={passOld:$("#OldPassword").val(),passNew:$("#NewPassword").val()};t("POST","https://localhost:44302/api/userControllers/edit/password/3",JSON.stringify(e))}))})();