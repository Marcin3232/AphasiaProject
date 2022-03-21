using DataBaseProject.Connection;
using DataBaseProject.InitEntity;
using DataBaseProject.Services;
using System.Text;

Console.WriteLine("Aphasia Database");
Console.WriteLine($"{DateTime.Now}");

var db = new DbConnection();
var conn = db.Connection();

if (conn == null)
{
    AppStop();
    return;
}

var entity = new Entity();

if (!entity.Initialize())
{
    AppStop();
    return;
}

var fillPhaseData = new FillExercisePhaseDbService();
var fillExerciseData = new FillExerciseDbService();
fillPhaseData.Fill();
fillExerciseData.Fill();

Console.WriteLine($"{DateTime.Now} || INFO: Finish database app.");

static string AppStop() =>
    $"{DateTime.Now} || Application Stoped!";