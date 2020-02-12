function [AllDistancesOther] = CorrelationForNew(TrainingSet,TestSet)
[a,~]=size(TrainingSet);
[b,~]=size(TestSet);
AllDistancesOther= zeros(1,1);
[Mean1] = Mean(TestSet(1,:));
for i=1:b
    if(b>1)
    [Mean1] = Mean(TestSet(i,:));
    end
    for j=1:a
    [SameMoviesMatrix] = SameMovies(TestSet(i,:),TrainingSet(j,:));
    [Mean2] = Mean(TrainingSet(j,:));
    [CorrelationCoef] = Correlation(SameMoviesMatrix,Mean1,Mean2);
    AllDistancesOther(i,j)= CorrelationCoef;
    end
end
end
