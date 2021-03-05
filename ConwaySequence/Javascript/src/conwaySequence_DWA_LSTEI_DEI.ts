export function getConwaySequenceForRow(targetRowNumber: number) : string
{
  if (targetRowNumber >= 80)
  {
    return "Sequence is too long to compute!";
  }

  if (targetRowNumber <= 1)
  {
    return "1";
  }
  
  return getConwaySequenceForRowRec(1, targetRowNumber, "1");
}

function getConwaySequenceForRowRec(
  currentRowNumber : number,
  targetRowNumber : number,
  lastConwayValue : string
)
{
  if (currentRowNumber >= targetRowNumber)
  {
    return lastConwayValue;
  }

  var currentConwayValue = calculateConwayValueRec(
    lastConwayValue.split(''),
    0,
    ''
  );

  return getConwaySequenceForRowRec(currentRowNumber + 1, targetRowNumber, currentConwayValue);
}

function calculateConwayValueRec(
  baseValue : string[],
  index : number,
  result : string
) : string
{
  if (index >= baseValue.length)
  {
    return result;
  }

  var currentChar = baseValue[index];

  var counted = countSequentialIdenticalCharactersRec(
    baseValue,
    currentChar,
    0,
    index
  );

  return calculateConwayValueRec(baseValue, counted.Index, result + counted.ResultString);
}

function countSequentialIdenticalCharactersRec(
  baseValue : string[],
  currentChar : string,
  currentAccumulatedCharCount : number,
  index : number
) : SequentialCharactersResult
{
  if (baseValue[index] === currentChar)
  {
    return countSequentialIdenticalCharactersRec(
      baseValue,
      currentChar,
      currentAccumulatedCharCount + 1,
      index + 1
    );
  }

  return new SequentialCharactersResult(currentAccumulatedCharCount.toString() + currentChar, index);
}

class SequentialCharactersResult
{
  constructor(resultString : string, index : number)
  {
    this._resultString = resultString;
    this._index = index;
  }

  private _resultString : string;
  public get ResultString() : string {
    return this._resultString;
  }
  
  private _index : number;
  public get Index() : number {
    return this._index;
  }
}
