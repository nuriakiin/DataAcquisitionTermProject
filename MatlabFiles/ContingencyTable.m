function [contTableMatrix] = ContingencyTable(TestThreeRate,PredictedThreeRate)
[row,column] = size(TestThreeRate);
contTableMatrix=zeros(2,2);
for i=1:row
    for j=1:column
        if(TestThreeRate(i,j)==PredictedThreeRate(i,j))
            if(TestThreeRate(i,j)==1)
                contTableMatrix(1,1) = contTableMatrix(1,1) + 1;
            else
                contTableMatrix(2,2) = contTableMatrix(2,2) + 1; 
            end
        else
            if (TestThreeRate(i,j)==1)
                contTableMatrix(1,2)= contTableMatrix(1,2) + 1;
            else
                contTableMatrix(2,1)= contTableMatrix(2,1) + 1;
            end
        end
    end
end

end

