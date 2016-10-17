namespace fsharpdata

open FSharp.Charting
open FSharp.Data

type Stocks = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=AAPL">

module public StockPlotter =
    let public Plot symbol = 
        let url = "http://ichart.finance.yahoo.com/table.csv?s=" + symbol
        let stock = Stocks.Load(url)

        Chart.Line([ for row in stock.Rows -> row.Date, row.Open ], Name = symbol).ShowChart()
        
 