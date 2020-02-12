function [mean] = Mean(user)
[~,a]=size(user);
sum=0;
count=0;

for i=1:a
    if(user(1,i) ~= -1)
    sum =sum+user(1,i);
    count = count +1;
    end
end
mean=sum/count;
end

