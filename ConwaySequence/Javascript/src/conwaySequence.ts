const MaxStringLengthExceededErrorMsg= "Sequence was too long to compute!";
// const MaxStringCompatLength = 1048576; //2^20 -> https://bytes.com/topic/javascript/answers/92088-max-allowed-length-javascript-string
const MaxStringCompatLength = 16777216; //2^24


export function getConwaySequenceForRow(targetRowNumber: number) {
  let resultRow = "1";
  for (let i = 1; i < targetRowNumber; i++) {
        resultRow = getNextRow(resultRow);
        if(resultRow == MaxStringLengthExceededErrorMsg)
          break;
  }
  return resultRow;
}

export function getNextRow(previousRow: string) {
  let nextRow = "";
  for (let i = 0; i < previousRow.length; true) {
    const prevNumber = previousRow.charAt(i);
    let nrOfPrevInteger = 1;
    i++;
    while(previousRow.charAt(i) == prevNumber)
    {
     nrOfPrevInteger++;
     i++;
    }
    nextRow += nrOfPrevInteger + prevNumber;
    if(nextRow.length > MaxStringCompatLength)
      return MaxStringLengthExceededErrorMsg;
  }
  return nextRow;
}