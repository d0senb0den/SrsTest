// See https://aka.ms/new-console-template for more information
using SrsTest;
using Newtonsoft.Json;

Console.WriteLine("Hello, please enter your username..");
User user = new(new List<SupportedProgram>());
user.Name = Console.ReadLine();

user.Id = 1;

Console.WriteLine("Please enter a supported program of your choice.. Enter by Id ( 1 , 2 or 3 ): ");
int input;
WrongId: 
while (int.TryParse(Console.ReadLine(), out input) == false)
{
    Console.WriteLine("Wrong input, please try again..");
}

switch (input)
{
    case 1:
        Console.WriteLine("Discord");
        user.SupportedPrograms.Add(new SupportedProgram(new List<SrsTrainableShortcut>()) { Id = 1 });
        break;
    case 2:
        Console.WriteLine("Visual Studio");
        user.SupportedPrograms.Add(new SupportedProgram(new List<SrsTrainableShortcut>()) { Id = 2 });
        break;
    case 3:
        Console.WriteLine("Notepad");
        user.SupportedPrograms.Add(new SupportedProgram(new List<SrsTrainableShortcut>()) { Id = 3 });
        break;
    default:
        Console.WriteLine($"Supported program by Id: {input} does not exist, please try again..");
        goto WrongId;
}


int input2;
Console.WriteLine("Which shortcuts do you want to use?");
WrongShortcut:
while (int.TryParse(Console.ReadLine(), out input2) == false)
{
    Console.WriteLine("Wrong input, please try again..");
}

switch (input2)
{
    case 1:
        Console.WriteLine("Ctrl + C = Copy");
        BuildShortcut(user, 1);
        break;
    case 2:
        Console.WriteLine("Ctrl + V = Paste");
        BuildShortcut(user, 2);
        break;
    case 3:
        Console.WriteLine("Ctrl + X = Cut");
        BuildShortcut(user, 3);
        break;
    default:
        goto WrongShortcut;
}

Console.WriteLine("Creating schema by id 1.");
Console.WriteLine("What is the CurrentSessionIndex?");
var schema = user.SupportedPrograms[0].Shortcuts[0].SrsSchema = new SrsSchema(null);
schema.ShortcutId = user.SupportedPrograms[0].Shortcuts[0].Id;
schema.Id = 1;
int index;
while (!int.TryParse(Console.ReadLine(), out index))
{
    Console.WriteLine("Wrong input, try again.");
}
schema.CurrentSessionIndex = index;
schema.SessionsAndPauseTimes = new List<ISessionAndPauseTime>();
Console.WriteLine("Creating sessions and pause times.");
for(int i = 0; i < 8; i++)
{
    schema.SessionsAndPauseTimes.Add(new SessionAndPauseTime(null));
    schema.SessionsAndPauseTimes[i].PauseTime = new TimeSpan(i, 0, 0);
    schema.SessionsAndPauseTimes[i].SrsSession = new SrsSession();
    var session = schema.SessionsAndPauseTimes[i].SrsSession;
    session.CurrentRepCount = new Random().Next(10);
    session.EndedTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour - 8 + i, 0, 0);
    session.MaxDuration = new TimeSpan(i + 1, 0, 0);
    session.DeadLine = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour - 8 + i, 0, 0);
    session.GoalRepCount = session.CurrentRepCount;
    session.State = "Completed";
    session.Id = i + 1;
    session.ScheduledDateTime = null;
}

string fileName = $"{AppContext.BaseDirectory}MockUser{user.Id}.json";
using (StreamWriter streamWriter = new(fileName, new FileStreamOptions() {Access = FileAccess.ReadWrite, Mode = FileMode.OpenOrCreate })) 
{
    streamWriter.WriteLine(JsonConvert.SerializeObject(user, new JsonSerializerSettings() { Formatting = Formatting.Indented }));
}

bool AskYesOrNoQuestion(string question)
{
    Console.WriteLine(question);
    var answer = Console.ReadLine().ToLower();
    while (answer != "yes" && answer != "no")
    {
        Console.WriteLine("Wrong input, please try again..");
    }
    bool yes = answer == "yes";

    return yes;
}

int AskAboutNumber(string question)
{
    Console.WriteLine(question);
    int answer;
    while (int.TryParse(Console.ReadLine(), out answer) == false)
    {
        Console.WriteLine("Wrong input, please try again..");
    }
    return answer;
}

string AskAboutLevel(string question)
{
    WrongLevel:
    Console.WriteLine(question);
    string answer = Console.ReadLine().ToLower();

    switch (answer)
    {
        case "easy":
            return "Easy";
        case "medium":
            return "Medium";
        case "hard":
            return "Hard";
        default:
            goto WrongLevel;
    }
}

void BuildShortcut(User user, int id)
{
    var builder = new SrsTrainableShortcutBuilder();
    builder.Create().SpecifyId(id);

    bool yes = AskYesOrNoQuestion("Is this shortcut mastered? Yes or No");
    builder.SpecifyIsMastered(yes);

    yes = AskYesOrNoQuestion("Has this shortcut been used before?");
    builder.SpecifyHasBeenUsed(yes);

    int deckIndex = AskAboutNumber("Which DeckIndex does this shortcut have?");
    builder.SpecifyDeckIndex(deckIndex);

    string level = AskAboutLevel("Which difficulty level is the shortcut on? Easy, Medium or Hard?");
    builder.SpecifyDifficultyLevel(level);

    user.SupportedPrograms[0].Shortcuts.Add(builder.Build());
}