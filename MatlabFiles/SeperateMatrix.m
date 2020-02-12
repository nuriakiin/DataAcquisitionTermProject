function [OutputMatrix] = SeperateMatrix(BinaryMatrix,i,j)
    
OutputMatrix = BinaryMatrix((i:j),:);

end

