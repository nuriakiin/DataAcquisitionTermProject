function [CosSimMatrix] = CosineSim(TrainingSet,TestSet)
[a,~]=size(TrainingSet);
[b,~]=size(TestSet);
CosSimMatrix= zeros(1,1);

for i=1:b
    
    for j=1:a
    [SameMoviesMatrix] = SameMovies(TestSet(i,:),TrainingSet(j,:));
    [~,b2]=size(SameMoviesMatrix);
    if(b2 >= 1)
    [cosineSimCoef]= calcCosine(SameMoviesMatrix);
    CosSimMatrix(i,j) = cosineSimCoef;
    else
        CosSimMatrix(i,j)= 0 ;
    end
    end
end

end

