open System.IO

let input =
    "day1.txt"
    |> File.ReadAllLines
    |> Array.map (fun l -> int l[0..4], int l[8..])
    |> Array.unzip
    ||> (fun l r -> Array.sort l, Array.sort r)

let part1 lhs rhs =
    Seq.zip lhs rhs |> Seq.map (fun (a, b) -> abs (a - b)) |> Seq.sum

let part2 lhs rhs =
    lhs
    |> Seq.countBy id
    |> Seq.map (fun (k, factor) ->
        let freq = rhs |> Array.filter (fun x -> x = k) |> Array.length
        k, (factor * freq))
    |> Seq.sumBy (fun (k, factor) -> k * factor)

printfn $"Part1: {input ||> part1}"
printfn $"Part2: {input ||> part2}"
