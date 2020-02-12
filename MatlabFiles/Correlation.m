function [CorrelationCoef] = Correlation(SameMovieMatrix,Mean1,Mean2)
[b,a]= size(SameMovieMatrix);
if(b==2)
    %[Mean1] = Mean(SameMovieMatrix(1,:));
    %[Mean2] = Mean(SameMovieMatrix(2,:));
count=0;
count2=0;
count3=0;
for i=1:a
count= count + (SameMovieMatrix(1,i)-Mean1)*(SameMovieMatrix(2,i)-Mean2);
count2 = count2 + ((SameMovieMatrix(1,i)-Mean1)*(SameMovieMatrix(1,i)-Mean1));
count3 = count3 + ((SameMovieMatrix(2,i)-Mean2)*(SameMovieMatrix(2,i)-Mean2));
end
x = sqrt(count2);
y = sqrt(count3);
x= x*y;
CorrelationCoef = count/x;
if(a<50)
    CorrelationCoef = CorrelationCoef*(a/50);
end
%Covarience = (count/a)-(Mean1*Mean2);
%s =std(SameMovieMatrix,[],2);
%CorrelationCoef = (Covarience)/(s(1,1)*s(2,1));
else
    CorrelationCoef = 0;
end
 
end

