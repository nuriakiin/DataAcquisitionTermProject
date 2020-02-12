function [kNeighbour,kNeighbourIndex] = KNNeighbour(AllCorrelationMatrix)
 AllCorrelationMatrix(isnan(AllCorrelationMatrix))=-1;
[sortedCorrelation,indexes] = sort(AllCorrelationMatrix,2,'descend');

  kNeighbour =sortedCorrelation(:,(1:40)); 
  kNeighbourIndex = indexes(:,(1:40)); 
    
   

end

