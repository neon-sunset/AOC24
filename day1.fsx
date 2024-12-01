open System.IO

let input =
    "day1.txt"
    |> File.ReadLines
    |> Seq.map (fun l -> int l[0..4], int l[8..])
    |> Seq.toArray
    |> Array.unzip

let part1 =
    let (lhs, rhs) = input
    Seq.zip (Seq.sort lhs) (Seq.sort rhs)
    |> Seq.map (fun (a, b) -> abs (a - b))
    |> Seq.sum

let part2 =
    let (lhs, rhs) = input
    lhs
    |> Seq.countBy id
    |> Seq.map (fun (k, factor) ->
        let freq = rhs |> Seq.filter (fun x -> x = k) |> Seq.length
        k, (factor * freq))
    |> Seq.sumBy (fun (k, factor) -> k * factor)

printfn "%d" part1
printfn "%d" part2
