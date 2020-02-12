function [sameMovieMatrix] = SameMovies(user1,user2)
sameMovieMatrix=zeros(1,1);
[~,sizeUser]= size(user1);
count=0;

for i=1:sizeUser
    
    if(user1(1,i)~=-1 && user2(1,i)~=-1)
        count=count+1;
    sameMovieMatrix(1,count)=user1(1,i);
    sameMovieMatrix(2,count)=user2(1,i);
    end
    
end
end

