function [TestThreeRate,TestSetIndexes] = FindTestRate(TestSet)
[satir , column] = size(TestSet);
data=zeros(1,1);
TestSetIndexes=zeros(1,1);
for i=1:satir
    count=0;
    j=1;
    while count<4 && j<column
        if(TestSet(i,j)~=-1 && count<3)
            count=count+1;
            data(i,count)=TestSet(i,j);
            TestSet(i,j)=0;
            TestSetIndexes(i,count)=j;
        end
        if count==3
            break;
        end
        j=j+1;
    end 
end
TestThreeRate=data;
end

