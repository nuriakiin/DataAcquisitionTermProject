function [cosineSim] = calcCosine(SameMoviesMatrix)
CrossProduct=0;
squareRoot1=0;
squareRoot2=0;
[row,column] = size(SameMoviesMatrix);
if(column==1 && row==2)
  CrossProduct= CrossProduct + (SameMoviesMatrix(1,1)*SameMoviesMatrix(2,1));
  squareRoot1= squareRoot1 + (SameMoviesMatrix(1,1)*SameMoviesMatrix(1,1));
  squareRoot2= squareRoot2 + (SameMoviesMatrix(2,1)*SameMoviesMatrix(2,1));
elseif(row==2)

    for i=1:column

  CrossProduct= CrossProduct + (SameMoviesMatrix(1,i)*SameMoviesMatrix(2,i));
  squareRoot1= squareRoot1 + (SameMoviesMatrix(1,i)*SameMoviesMatrix(1,i));
  squareRoot2= squareRoot2 + (SameMoviesMatrix(2,i)*SameMoviesMatrix(2,i));

    end
end

cosineSim = CrossProduct / (((sqrt(squareRoot1))*(sqrt(squareRoot2))));

if (column<50)
    cosineSim=cosineSim * (column/50);
end

end

