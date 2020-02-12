function [prediction] = UserBasedKNN(datasetName,userId,movieId)
Data = readmatrix(datasetName);
[Edited] = Edit(Data);
userRates=Edited(userId,:);
[AllDistancesOther] = CorrelationForNew(Edited,userRates);
[a,index] =  sort(AllDistancesOther(1,:),'descend');
[guess] = calcPrediction(a,index,Edited,userRates,50,movieId);
prediction =round(guess);
end



function [guess] = calcPrediction(a,index,AllData,userRates,k,movieId)
[~,column]=size(a);
actualRate = 0;
sumOfValues=0;
sumOfSims=0;
count=0;
for i=1:column
    actualRate = AllData(index(1,i),movieId);
    [Mean1]= Mean(AllData(index(1,i),:));
    if((actualRate)~= -1 && count<k)
    sumOfValues = sumOfValues + (a(1,i)*(actualRate-Mean1));
    sumOfSims= sumOfSims+ a(1,i);
    count = count +1;
    end
end
[MeanP] = Mean(userRates(1,:));
guess= (MeanP + (sumOfValues/sumOfSims));
end
