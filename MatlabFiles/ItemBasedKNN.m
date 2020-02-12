function [prediction] = ItemBasedKNN(datasetName,userId,movieId)
Data = readmatrix(datasetName);
[ItemEdited] = transpose(Edit(Data));
movieRates=ItemEdited(movieId,:);
[CosineSimMatrix]= CosineSim(ItemEdited,movieRates);
[a,index] =  sort(CosineSimMatrix(1,:),'descend');
[prediction] = calcItemPrediction(a,index,ItemEdited,50,userId);

end


function [guess] = calcItemPrediction(a,index,AllData,k,userId)
[~,column] = size(a);
count=0;
countRateSim=0;
sumofSim=0;
    for i=1:column
        if(AllData(index(1,i),userId)~=-1 && count<k)
        countRateSim= countRateSim + ((a(1,i))*(AllData(index(1,i),userId)));
        sumofSim= sumofSim + a(1,i);
        count=count+1;
        end
    end
Prediction = countRateSim / sumofSim ; 
guess=round(Prediction);
end