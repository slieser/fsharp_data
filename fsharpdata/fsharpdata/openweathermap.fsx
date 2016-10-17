#load "../packages/FsLab.0.3.16/FsLab.fsx"
open FSharp.Data
open XPlot.GoogleCharts

type Weather = JsonProvider<"http://api.openweathermap.org/data/2.5/forecast/daily?units=metric&q=Berlin&APPID=a9c109600b5773dcea163ea4fce3bf5e">

let w = Weather.GetSample() 
printfn "%s" w.City.Country 
for day in w.List do
    printfn "%f" day.Temp.Max

//---------------------

let baseUrl = "http://api.openweathermap.org/data/2.5"
let forecastUrl = baseUrl + "/forecast/daily?units=metric&APPID=a9c109600b5773dcea163ea4fce3bf5e&q="
let getTomorrowTemp place =
    let w = Weather.Load(forecastUrl + place)
    let tomorrow = Seq.tryHead w.List
    match tomorrow with
        | None -> -100m
        | t -> t.Value.Temp.Max

getTomorrowTemp "Berlin"
getTomorrowTemp "Cologne"
getTomorrowTemp "West Bank and Gaza"

//----------------------------------
let wb = WorldBankData.GetDataContext()

let worldTemps =
    [ for c in wb.Countries ->
        let place = c.CapitalCity + "," + c.Name
        printfn "Getting temperature in: %s" place
        c.Name, getTomorrowTemp place ]

let colors = [| "#80E000";"#E0C000";"#E07B00";"#E02800" |]
let values = [| 0;+15;+30;+45 |]
let axis = ColorAxis(values=values, colors=colors)

worldTemps
|> Chart.Geo
|> Chart.WithOptions(Options(colorAxis=axis))
|> Chart.WithLabel "Temp"
