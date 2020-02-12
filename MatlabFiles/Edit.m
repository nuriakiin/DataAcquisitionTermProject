function [EditedMatrix] = Edit(Data)
[row,~]=size(Data);
Edited=zeros(1,1);

for i=1:row
    Edited(Data(i,1),Data(i,2))=Data(i,3);
end
    Edited(~Edited)=-1; 
EditedMatrix = Edited;

end

