function [error] = MAE(Prediction,TestSet)
count=0;
n=0;
Prediction(isnan(Prediction))=0;
[row,column] = size(Prediction);
for i=1:row

      if (Prediction(i,1)~=0)
        count = count + abs(Prediction(i,1)-TestSet(i,1));
        n=n+1;
    
      end

end
error = count/n;
end
