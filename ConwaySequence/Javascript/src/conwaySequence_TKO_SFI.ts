export function 
  getConwaySequenceForRow(
    targetRowNumber: number
  ) 
{
  if(targetRowNumber>=80)
    return "Sequence is too long to compute!";
  targetRowNumber = Math.round(targetRowNumber);
    var current:string = "1"
  for(var i=0;i<targetRowNumber-1;i++)
    current = getConwaySequenceForInput(current);
  return current;
}

export function getConwaySequenceForInput(input:string = null) 
{
  var result = "";
  var chars = input.split('');

  var pos = 0;
  while(chars[pos] != undefined)
  {
    var count = 1;
    var currentChar = chars[pos];
    while( chars[pos] == chars[++pos] )
    {
      count++;
    }
    result += count+currentChar;
  }
  return result;
}