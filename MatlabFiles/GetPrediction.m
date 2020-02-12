function [Prediction1,Prediction2,Prediction3] = GetPrediction(a,index,TrainingSet,TestSet,TestSetIndexes,xx,k)
[row,column]=size(a);
actualRateColumn1 = 0;
actualRateColumn2 = 0;
actualRateColumn3 = 0;
sumOfValuesC1=0;
sumOfValuesC2=0;
sumOfValuesC3=0;
sumOfSimsC1=0;
sumOfSimsC2=0;
sumOfSimsC3=0;
count=0;
for i=1:column
    actualRateColumn1 = TrainingSet(index(1,i),TestSetIndexes(xx,1));
%     actualRateColumn2 = TrainingSet(index(1,i),TestSetIndexes(xx,2));
%     actualRateColumn3 = TrainingSet(index(1,i),TestSetIndexes(xx,3));
    [Mean1]= Mean(TrainingSet(index(1,i),:));
    if((actualRateColumn1)~= -1 && count<k)
    sumOfValuesC1 = sumOfValuesC1 + (a(1,i)*(actualRateColumn1-Mean1));
    sumOfSimsC1= sumOfSimsC1+ a(1,i);
    count = count +1;
    end
%     if((actualRateColumn2)~= -1)
%     sumOfValuesC2 = sumOfValuesC2 + (a(1,i)*(actualRateColumn2-Mean1));
%     sumOfSimsC2= sumOfSimsC2+ a(1,i);
%     end
%     if((actualRateColumn3)~= -1)
%     sumOfValuesC3 = sumOfValuesC3 + (a(1,i)*(actualRateColumn3-Mean1));
%     sumOfSimsC3= sumOfSimsC3+ a(1,i);
%     end
end
[MeanP] = Mean(TestSet(xx,:));
Prediction1= (MeanP + (sumOfValuesC1/sumOfSimsC1));
% Prediction2= (MeanP + (sumOfValuesC2/sumOfSimsC2));
% Prediction3= (MeanP + (sumOfValuesC3/sumOfSimsC3));
Prediction2=0;
Prediction3=0;

end 

