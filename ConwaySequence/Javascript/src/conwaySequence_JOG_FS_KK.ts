export function getConwaySequenceForRow(targetRowNumber: number) {
  if (targetRowNumber < 2) {
    return "1";
  }

  if (targetRowNumber > 50) {
    return "Sequence is too long to compute!";
  }

  if (targetRowNumber % 1 > 0) {
    targetRowNumber = Math.floor(targetRowNumber);
  }

  return getConwaySequenceResultForRow("1", targetRowNumber);
}

function getConwaySequenceResultForRow(inputRowString: string, interationsLeft: number){
  var result: string = "";
  var count: number = 0;
  var currentResult: string;

  for(var i = 0; i < inputRowString.length; i++){
    if(currentResult == undefined || currentResult != inputRowString[i]){
      addPartialResult(count);
      currentResult = inputRowString[i];
      count = 1;
    }else{
      count++;
    }
  }

  addPartialResult(count);

  if(interationsLeft > 2){
    return getConwaySequenceResultForRow(result, interationsLeft-1);
  }

  return result;

  function addPartialResult(count: number) {
    if (count > 0) {
      result += count;
      result += currentResult;
    }
  }
}