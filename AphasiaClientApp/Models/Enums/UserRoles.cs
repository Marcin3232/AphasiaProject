﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Enums
{
	public enum UserRoles
	{
		[Display(Name = "Administrator")]
		Admin = 1,
		[Display(Name = "Opiekun")]
		Guardian = 2,
		[Display(Name = "Logopeda")]
		SpeechTherapist = 3,
		[Display(Name = "Pacjent")]
		Patient = 4,
	}

	public enum UserRegisterRoles
    {
		[Display(Name = "Opiekun")]
		Guardian = 2,
		[Display(Name = "Logopeda")]
		SpeechTherapist = 3,
	}
}