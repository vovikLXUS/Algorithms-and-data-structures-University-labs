def color_stones(stones: str) -> int:
    # write your code here
    count = 0
    for i in range(len(stones) - 1):
        if stones[i] == stones[i + 1]:
            count += 1
    print(count)
    return count


color_stones("RRGB") # 1, "R" потрібно прибрати; в результаті залишиться "RGB"
color_stones("RRGGB") # 2, "R" і "G" потрібно прибрати; в результаті залишиться "RGB"
color_stones("RRRRGB") # 3, "RRR" потрібно прибрати; в результаті залишиться "RGB"
color_stones("RGBRGBRGGB") # 1, "G" потрібно прибрати в результаті залишиться "RGBRGBRGB"
color_stones("RGGRGBBRGRR") # 3, "G", "B" і "R" потрібно прибрати; в результаті залишиться "RGRGBRGR"
color_stones("RRRRGGGGBBBB") # 9, "RRR", "GGG" і "BBB" потрібно прибрати; в результаті залишиться "RGB"