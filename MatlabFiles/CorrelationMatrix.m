function [CorrelationMatrix] = CorrelationMatrix(AllData)
[row,~]=size(AllData);
CorrelationMatrix= zeros(1,1);
for i=1:row
    [Mean1] = Mean(AllData(i,:));
    for j=1:row
        if j>i
        [SameMoviesMatrix]= SameMovies(AllData(i,:),AllData(j,:));
        
        [Mean2] = Mean(AllData(j,:));
        [CorrelationCoef] = Correlation(SameMoviesMatrix,Mean1,Mean2);
        CorrelationMatrix(i,j)=CorrelationCoef;
        end
        
    end
end
    
end

