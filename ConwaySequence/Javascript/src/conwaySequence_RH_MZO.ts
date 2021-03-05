export function getConwaySequenceForRow(targetRowNumber: number) 
{
  let sequence = "1";
  
  
  for(let i = 1; i < targetRowNumber; i++)
  {
    sequence = getNextSequence(sequence);
  }
  return sequence;
}

export function getStringArray(input: string)
{
  return input.split('');
}

export function getNextSequence(input: string)
{
   let inputarray = getStringArray(input);

  let i = 0;
  let count = 1;
  let nextSequence = "";
  while(i < inputarray.length){
    if(compareWithNextPosition(inputarray, i))
    {
      count++;
    }
    else
    {
      nextSequence = nextSequence + count.toString() + inputarray[i];
      count = 1;
    }
    i++;
  }
  return nextSequence;
}

export function compareWithNextPosition(inputarray : string[], position: number ): boolean
{
  return inputarray[position] === inputarray[position+1]
}
