function [Prediction] = ItemBasePrediction(a,index,TestSet,TrainingSet,TestThreeRateIndexOrg,k,knn)
[~,column] = size(a);
count=0;
countRateSim=0;
sumofSim=0;

    for i=1:column
        if(TrainingSet(index(1,i),TestThreeRateIndexOrg(k,1))~=-1 && count<knn)
        countRateSim= countRateSim + ((a(1,i))*(TrainingSet(index(1,i),TestThreeRateIndexOrg(k,1))));
        sumofSim= sumofSim + a(1,i);
        count=count+1;
        end
    end
Prediction = countRateSim / sumofSim ; 

end

