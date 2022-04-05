using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Enums
{
	public enum UserRoles
	{
		[Display(Name = "Administrator")]
		Administrator = 1,
		[Display(Name = "Opiekun")]
		Guardian = 2,
		[Display(Name = "Logopeda")]
		SpeechTherapist = 3,
		[Display(Name = "Pacjent")]
		Patient = 4,
	}

	public enum UserRegisterRoles
    {
		[Display(Name = "Administrator")]
		Administrator = 1,
		[Display(Name = "Opiekun")]
		Guardian = 2,
		[Display(Name = "Logopeda")]
		SpeechTherapist = 3,
		[Display(Name = "Pacjent")]
		Patient = 4,
	}
	public enum UserPersonalRoles
    {
		[Display(Name = "Opiekun")]
		Guardian = 1,
		[Display(Name = "Logopeda")]
		SpeechTherapist = 2,
	}
}
